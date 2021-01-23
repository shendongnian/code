        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationService.Navigate(new Uri("/Live.xaml", UriKind.Relative));
        }
