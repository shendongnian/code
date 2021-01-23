        public MainWindow()
        {
            InitializeComponent();
        }
        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            expanderRow.Height = expandedHeight;
            expander.Visibility = Visibility.Visible;
        }
        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            expandedHeight = expanderRow.Height;
            expanderRow.Height = GridLength.Auto;
            expander.Visibility = Visibility.Collapsed;
        }
