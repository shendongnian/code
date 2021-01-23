    //Setting up the image
    Image image = new Image();
    image.Height = 70;
    image.Width = 70;
    BitmapImage bitmapImage = new BitmapImage();
    bitmapImage.UriSource = new Uri("http://url-of-the-image", UriKind.Absolute);
    image.CacheMode = new BitmapCache();
    image.Source = bitmapImage;
    image.Stretch = Stretch.UniformToFill;
    image.VerticalAlignment = System.Windows.VerticalAlignment.Center;
    
    //Setting up the mask
    RadialGradientBrush opacityMask = new RadialGradientBrush();
    GradientStop gs1 = new GradientStop();
    GradientStop gs2 = new GradientStop();
    GradientStop gs3 = new GradientStop();
    gs1.Color = Color.FromArgb(255, 0, 0, 0);
    gs1.Offset = 0.0;
    gs2.Color = Color.FromArgb(255, 0, 0, 0);
    gs2.Offset = 0.999;
    gs3.Color = Color.FromArgb(0, 0, 0, 0);
    gs3.Offset = 1.0;
    opacityMask.GradientStops.Add(gs1);
    opacityMask.GradientStops.Add(gs2);
    opacityMask.GradientStops.Add(gs3);
    
    //Setting up the StackPanel
    StackPanel sp = new StackPanel();
    sp.OpacityMask = opacityMask;
    
    //Showing the image
    sp.Children.Add(image);
    panel.Children.Add(sp);
