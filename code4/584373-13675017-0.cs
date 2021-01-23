       private void contentGrid_Tapped(object sender, TappedRoutedEventArgs e)
       {
            Uri uri = new Uri("ms-appx:///Images/Test.png");
            BitmapImage bitmap = new BitmapImage(uri);
            Image image = new Image();
            image.Source = bitmap;
    
    
            // The .png is a 30px by 30px image
            image.Width = 30;
            image.Height = 30;
            image.Stretch = Stretch.None;
    
            image.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            image.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Point tappedPoint = e.GetPosition(contentGrid);
            contentGrid.Children.Add(image);
            image.Margin = new Thickness(tappedPoint.X, tappedPoint.Y, 0, 0);
        }
