    public partial class MainWindow : Window
        {
            private WindowViewModel _wvm;
            public MainWindow()
            {
                InitializeComponent();
                _wvm = new WindowViewModel();
                this.DataContext = _wvm;
            }
      
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                _wvm.PopulateData();
            }
        }
