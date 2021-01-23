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
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public List<Example> listExample { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                this.listExample = new List<Example>();
                listExample.Add(new Example { IsChecked = false, Test1 = "teste" });
                listExample.Add(new Example {IsChecked = false, Test1 = "TTTTT!" });
                DataContext = this;
            }
    
            private void CheckBox_Checked(object sender, RoutedEventArgs e)
            {
    
            }
    
            private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
            {
    
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                this.listExample.ForEach(x => x.IsChecked = false);
    
            }
        }
    }
