    public MainWindow()
    {
        InitializeComponent();
			
        Bitmap bitMap = new Bitmap(@"\path\to\image.png");
        MemoryStream ms = new MemoryStream();
        bitMap.Save(ms, ImageFormat.Png);
        ms.Seek(0,SeekOrigin.Begin);
			
        BitmapImage bitMapImage = new BitmapImage();
        bitMapImage.BeginInit();
        bitMapImage.StreamSource = ms;
        bitMapImage.EndInit();
        Image image = new Image();
        image.Source = bitMapImage;
        image.Height = 100;
		
        Button button = new Button();
        button.Height = 200;
        button.Width = 200;
        button.Content = image;
        button.Style = button.Style = (Style)FindResource("myButtonStyle");
        myGrid.Children.Add(button);
     } 
