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
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                listView2.Items.Add((listView1.SelectedItem));
            }
            private void Grid_Loaded(object sender, RoutedEventArgs e)
            {
                listView1.Items.Add("test 1");
                listView1.Items.Add("test 2");
            }
        }
    }
