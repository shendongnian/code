        ObservableCollection<string> items = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            itemsControl.ItemsSource = items;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            items.Add("New Item");
        }
