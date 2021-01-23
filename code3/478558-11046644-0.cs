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
    using System.Windows.Threading;
    
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                for (int i = 0; i < 2; i++)
                {
                result res = null;     
                if (i == 0)
                res = new result { Comments = "First Time Round" };
                
                if (i == 1)
                    res = new result { Comments = "Total hard type" };
    
                Dispatcher.Invoke(DispatcherPriority.Loaded, new Action(delegate
                    {   
                        this.DataContext = res;
                    }
                ));
                
                System.Threading.Thread.Sleep(500);
    
                Dispatcher.Invoke(DispatcherPriority.Loaded, new Action(delegate
                {
                    PrintDialog dialog = new PrintDialog();
                    dialog.PrintVisual(this.canvas1, "");
                }
            ));
                System.Threading.Thread.Sleep(500);
    
                }
            }
        }
    
        class result
        {
            public string Comments { get; set; }
        }
    }
