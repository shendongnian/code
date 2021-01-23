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
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            List<TextBox> tboxList = new List<TextBox>();
            List<TextBlock> tblockList = new List<TextBlock>();
            public MainWindow()
            {
                InitializeComponent();
                tblockList.Add(textBlock1);
                tblockList.Add(textBlock2);
                tblockList.Add(textBlock3);
                tblockList.Add(textBlock4);
                tblockList.Add(textBlock5);
                tblockList.Add(textBlock6);
                tblockList.Add(textBlock7);
                tblockList.Add(textBlock8);
                tblockList.Add(textBlock9);
                tboxList.Add(textBox1);
                tboxList.Add(textBox2);
                tboxList.Add(textBox3);
                tboxList.Add(textBox4);
                tboxList.Add(textBox5);
                tboxList.Add(textBox6);
                tboxList.Add(textBox7);
                tboxList.Add(textBox8);
                tboxList.Add(textBox9);
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (tboxList[i].Visibility == Visibility.Collapsed)
                    {
                        tboxList[i].Visibility = Visibility.Visible;
                        tblockList[i].Visibility = Visibility.Visible;
                        break;
                    }
                }
            }
        
        }
    }
