    storageFile.OpenAsync(FileAccessMode.Read).ContinueWith(task => {
      FileRandomAccessStream stream = (FileRandomAccessStream)task.Result;
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.SetSource(stream);
      Image image = new Image();
      image.Source = bitmapImage;
      Images.Add(image);
    });
