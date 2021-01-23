    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(MyViewModel.RequestCloseEvent, new RoutedEventHandler(onRequestClose));
        }
    
        private void onRequestClose(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
