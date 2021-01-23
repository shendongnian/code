    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Threading;
    using System.IO;
    
    namespace Multithreading1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            List<int> myList = new List<int>();
            int threadNumber = 0;
            int currentRecNumber = -1;
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            void ThreadHandler(int recNumber,int number)
            {
                Action action = null;
                action = () =>
                        {
                            myList[recNumber] = number;
                            ++currentRecNumber;
                            --threadNumber;
                            int localCurrentRecNumber = currentRecNumber;
                            int localThreadNumber = threadNumber;
                            if (localCurrentRecNumber < myList.Count)
                            {
                                ++threadNumber;
                                Thread t = new Thread(() => GetRandomNumber(localCurrentRecNumber));
                                t.Start();
                            }
                            else
                                if (localThreadNumber == 0) //finish
                                {
                                    List<String> stringList = new List<String>();
                                    for (int i = 0; i < myList.Count;i++)
                                    {
                                        stringList.Add(myList[i].ToString());
                                    }
                                    File.WriteAllLines("C:\\Users\\Public\\Documents\\MyList.txt", stringList);
                                    System.Windows.MessageBox.Show("Finish");
                                }
                        };
                this.Dispatcher.BeginInvoke(action);
            }
    
            void GetRandomNumber(int recNumber)
            {
                Random rnd = new Random();
                int randomInt = rnd.Next(1, 13);
                ThreadHandler(recNumber, randomInt);
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                for (int i = 0; i < 20000; i++)
                {
                    myList.Add(-1);
                }
                for (int i = 0; i < 3; i++)
                {
                    ++currentRecNumber;
                    ++threadNumber;
                    int localCurrentNumber = currentRecNumber;
                    Thread t = new Thread(() => GetRandomNumber(localCurrentNumber));
                    t.Start();
                }
            }
        }
    }
