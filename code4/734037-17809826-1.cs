        public MainWindow()
        {        
            InitializeComponent();
        }
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            image1.MainIcon  = new BitmapImage(new Uri("Images/laptop.png", UriKind.Relative));
        }
        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            image1.MainIcon  = new BitmapImage(new Uri("Images/trashcan.png", UriKind.Relative));
        }
        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            image1.StatusIcon  = new BitmapImage(new Uri("Images/warning.png", UriKind.Relative));
        }
        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            image1.StatusIcon  = new BitmapImage(new Uri("Images/battery.png", UriKind.Relative));
        }
        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            image1.StatusIcon = new BitmapImage(new Uri("Images/null.png", UriKind.Relative));
        }
    }
