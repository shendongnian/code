    Dispatcher.BeginInvoke(() =>
    {
        globalWrapper = (PhotoWrapper)JsonConvert.DeserializeObject(
                                          response.Content, typeof(PhotoWrapper));
        tempImage = new BitmapImage();
        tempImage.BeginInit();
        tempImage.CacheOption = BitmapCacheOption.OnLoad;
        tempImage.SetSource(new MemoryStream(globalWrapper.PictureBinary, 0,
                                             globalWrapper.PictureBinary.Length));
        tempImage.EndInit();
        globalWrapper.ImageSource = tempImage;
        PictureList.Items.Add(globalWrapper);
    });
