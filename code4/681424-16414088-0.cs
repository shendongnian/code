    public MainPage()
    {
      this.InitializeComponent();
      this.Loaded += MainPage_Loaded;
    
    }
    
    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
      var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/shrimp.jpg"));
      var fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
    
      var image = new BitmapImage();
    
      image.SetSource(fileStream);
    
      qButton1.Icon = image;
        }
