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
    
    namespace StackOverflowWpf2
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public BorderViewModel ViewModel { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
    
                ViewModel = new BorderViewModel();
    
                this.DataContext = ViewModel;
    
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                var vis = (this.DataContext as BorderViewModel).BorderVisible;
    
                (this.DataContext as BorderViewModel).BorderVisible = !vis;
                
            }
        }
    }
