    if (e.TaskResult == TaskResult.OK)
    {
        BitmapImage bi = new BitmapImage();
        bi.SetSource(e.ChosenPhoto);
        WriteableBitmap b = new WriteableBitmap(bi);
        Image img = new Image();
        img.Source = b;           
        Canvas.SetLeft(img, 10);
        Canvas.SetTop(img, 10);
        area.Children.Add(img);    
    }
