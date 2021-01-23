    ImageBrush brush = new ImageBrush();
    brush.ImageSource = new BitmapImage(new Uri("/myImage.jpg", UriKind.Relative));
    //hide the fake button and set the brush to be its background
    button1.Visibility = System.Windows.Visibility.Collapsed;
    button1.Background = brush;
    //assign it to the frame (or using RootFrame in your case)
    var frame = App.Current.RootVisual as PhoneApplicationFrame;
    frame.Background = brush;
