    Image image = new Image();
    Uri uri = new Uri("/Images/marker_stop.png", UriKind.Relative);
    BitmapImage bi = new BitmapImage(uri);
    bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
    image.Source = bi;
    System.Diagnostics.Debug.WriteLine("************************************* in image.ActualWidth " + ", " + bi.PixelWidth); // return 30
