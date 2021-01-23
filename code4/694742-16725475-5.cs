    using System.Windows;
    
    namespace WpfApplication
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void OnTestButtonClicked(object sender, RoutedEventArgs e)
            {
                ((ViewModel)this.DataContext).Test();
            }
        }
    }
