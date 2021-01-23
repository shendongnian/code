    using System.Windows;
    
    namespace WpfApplication16
    {
        public partial class MainWindow : Window
        {
            private MySuperDataContextClass _mySuperDataContextClass = 
                                               new MySuperDataContextClass();
    
            public MainWindow()
            {
                InitializeComponent();
    
                this.DataContext =_mySuperDataContextClass;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (_mySuperDataContextClass.MySuperCheckBoxIsChecked)
                {
                    MySuperTextBlock.Text = 
                       _mySuperDataContextClass.MySuperFloatValue.ToString();
                }
                else
                {
                    MySuperTextBlock.Text = 0.0f.ToString();
                }
            }
        }
    }
