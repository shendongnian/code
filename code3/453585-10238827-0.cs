    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
      var file = await localFolder.CreateFileAsync(".txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
      var t = await file.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.DocumentsView);
      var bmp = new BitmapImage();
      bmp.SetSource(t); //Exception here
      image.Source = bmp;
    }
