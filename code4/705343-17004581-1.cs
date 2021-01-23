    var imageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(
      "test.png", CreationCollisionOption.ReplaceExisting);
    /*
    var fs = await imageFile.OpenAsync(FileAccessMode.ReadWrite);
    DataWriter writer = new DataWriter(fs.GetOutputStreamAt(0));
    writer.WriteBytes(await response.Content.ReadAsByteArrayAsync());
    await writer.StoreAsync();
    writer.DetachStream();
    await fs.FlushAsync();
    writer.Dispose();
    if (Uri.TryCreate(imageFile.Path, UriKind.RelativeOrAbsolute, out imageUri))
    {
        image = new BitmapImage(imageUri);
    }
    */
    var fs = await imageFile.OpenStreamForWriteAsync();
    await response.Content.CopyToAsync(fs);
    await fs.FlushAsync();
    // you may want to have this Dispose as part of a 
    // finally block (try/ catch/ finally)
    fs.Dispose();
    var bs = await imageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
    image = new BitmapImage();
    image.SetSource(bs);
    ...
    image1.Source = image;
