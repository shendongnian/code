    public MainWindow()
    {
        InitializeComponent();
        BitmapImage bmp = new BitmapImage();
        bmp.BeginInit();
        bmp.UriSource = new Uri("image.png", UriKind.RelativeOrAbsolute);
        bmp.EndInit();
        MyImage.Source = bmp;
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        RenderTargetBitmap bmp = new RenderTargetBitmap((int)MyGrid.ActualWidth,
                (int)MyGrid.ActualHeight, 96, 96, PixelFormats.Default);
        bmp.Render(MyImage);
        PngBitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bmp));
        using (var stream = System.IO.File.Create("newimage.png"))
        { encoder.Save(stream); }
    }
