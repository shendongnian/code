    void OnButtonClick(object sender, RoutedEventArgs routedEventArgs)
    {
        var files = Directory.GetFiles(@"C:\img");
        foreach (var file in files)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(file);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            var img = new Image { Source = bitmap };
            img.MouseDown += OnImageMouseDown;
            //Add img to your container
        }
    }
    void OnImageMouseDown(object sender, MouseButtonEventArgs e)
    {
        var img = sender as Image;
        //Operate
    }
