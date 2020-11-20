using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace matrica
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static bool Equals(int[] m1, int[] m2)
        {
            if (m1.Length == m2.Length)
            {
                for (int i = 0; i < m1.Length; i++)
                {
                    if (!m1[i].Equals(m2[i]))
                        return false;
                }
                return true;
            }
            return false;
        }
        private static int[] Bubble(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[j] < A[i])
                    {
                        var temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;
                    }
                }
            }
            return A;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int m, n;
            int k = 0; // счетчик повторяющихся строк
            m = int.Parse(count1.Text);
            n = int.Parse(count2.Text);
            int[] mas = new int[m]; // изначаальный
            int[] ma = new int[20]; //идеальный массив
            int[] ma1 = new int[20]; // сравнивающийся
            int[,] array = new int[n,m];
            for(int i = 0; i < n; i++) 
            {
                for(int j = 0; j < m; j++)
                {
                    array[i, j] = rnd.Next(0, 5);
                    result.Text += array[i, j] + " ";
                }
                result.Text += Environment.NewLine;
            }
            for (int i = 0; i < m; i++) //занос 1 строки в массив
            {
                mas[i] = array[0, i];
                //result.Text += mas[i] + " " + Environment.NewLine;
            }
            mas = Bubble(mas);
            ma[0] = mas[0];
            //result.Text += ma[0] + " " + Environment.NewLine;
            for (int i = 1, j = 1; i < mas.Length; i++) //Получение массива "Множества чисел" с чем сравнивать
            {
                if (mas[i] == mas[i - 1]) continue;
                ma[j] = mas[i];
                //result.Text += ma[j] + " " + Environment.NewLine;
                j++;
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[j] = array[i, j];
                }
                    mas = Bubble(mas);
                    ma1[0] = mas[0];
                    for (int z = 1, x = 1; z < mas.Length; z++) //Получение массива "Множества чисел" что сравнивать
                    {
                        if (mas[z] == mas[z - 1]) continue;
                        ma1[x] = mas[z];
                        //result.Text += ma1[x] + " " + Environment.NewLine;
                        x++;
                    }
                    if (Equals(ma,ma1))
                    {
                        k++;
                    }
                Array.Clear(mas, 0, mas.Length);
                Array.Clear(ma1, 0, mas.Length);
            }
            result.Text += $"k=: {k}" + Environment.NewLine;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            result.Text = "";
        }
    }
}
