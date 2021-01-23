    Uri uri = new Uri("/Images/ball1.png", UriKind.Relative);
    ImageSource img = new System.Windows.Media.Imaging.BitmapImage(uri);
    image.SetValue(Image.SourceProperty, img);
    cv.Children.Add(image);
    // Position the image on the canvas
    Canvas.SetLeft(150);
    Canvas.SetTop(200);
