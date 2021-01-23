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
    using System.ComponentModel;
    using System.Threading;
    
    namespace RectangleNS
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
                BackgroundWorker bw = new BackgroundWorker();
    
                Grid grid = (Grid)(sender as Button).Parent;
    
                bw.DoWork += (o, ee) => 
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Rectangle rectr = null;
                        Application.Current.Dispatcher.Invoke((Action)(() => { rectr = VTHelper.FindVisualChildByName<Rectangle>(grid, "rect" + i); }));
                        Application.Current.Dispatcher.Invoke((Action)(() => { rectr.Fill = Brushes.Black; }));                 
                        Thread.Sleep(100);
                    } 
                };
    
                bw.RunWorkerAsync();
            }
        }
    
        public static class VTHelper
        {
            public static T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    string controlName = child.GetValue(Control.NameProperty) as string;
                    if (controlName == name)
                    {
                        return child as T;
                    }
                    else
                    {
                        T result = FindVisualChildByName<T>(child, name);
                        if (result != null)
                            return result;
                    }
                }
                return null;
            }
        }
    }
