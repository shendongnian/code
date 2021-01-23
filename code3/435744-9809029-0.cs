     public MainPage()
            {
                InitializeComponent();
                Loaded += (s, e) => DataContext = new MainPageViewModel();
            }
    
            private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
                NavigationService.Navigate(new Uri("/views/browser.xaml?url=" + e.AddedItems[0], UriKind.Relative));
            }
