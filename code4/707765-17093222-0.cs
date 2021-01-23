    public MainPage()
    {
         this.InitializeComponent();
    
         NavigationCacheMode = NavigationCacheMode.Required;
         this.Loaded += MainPage_Loaded;
    }
    
    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
         lvProductVariants.ItemsSource = null; // Reset 
          Bind();
    }
