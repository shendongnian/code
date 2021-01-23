    using System.Windows;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show(ucw.Text);
            }
        }
    }
