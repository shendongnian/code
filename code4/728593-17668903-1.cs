     public MainPage()
     {
          InitializeComponent();
          this.Loaded += MainPage_Loaded;
          // Sample code to localize the ApplicationBar
          //BuildLocalizedApplicationBar();
     }
      void MainPage_Loaded(object sender, RoutedEventArgs e)
      {
          var graphics = new Graphics();
          this.ContentPanel.DataContext = graphics;
      }
