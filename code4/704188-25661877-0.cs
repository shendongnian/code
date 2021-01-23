    private async Task StoreImageFromClipboardAsync()
    {
      var dataPackage = Clipboard.GetContent();
      if (datapackage.Contains(StandardDataFormats.Bitmap))
      {
        var t = await dataPackage.GetBitmapAsync();
        var file = await SaveToPngTaskFile(t, ApplicationData.Current.LocalFolder, 
          "Clipboard.png");
      }
    }
    public static async Task<StorageFile> SaveToPngTaskFile
      (IRandomAccessStreamReference rndAccessStreamReference, 
       StorageFolder storageFolder, String storageFileName)
    {
      IRandomAccessStreamWithContentType rndAccessStreamWithContentType = 
        await rndAccessStreamReference.OpenReadAsync();
      StorageFile storageFile = 
        await storageFolder.CreateFileAsync(storageFileName, 
          CreationCollisionOption.GenerateUniqueName);
      var decoder = await BitmapDecoder.CreateAsync(rndAccessStreamWithContentType);
      var pixels = await decoder.GetPixelDataAsync();
      var outStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);
      var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, outStream);
      encoder.SetPixelData(decoder.BitmapPixelFormat, BitmapAlphaMode.Ignore,
        decoder.OrientedPixelWidth, decoder.OrientedPixelHeight,
        decoder.DpiX, decoder.DpiY,
        pixels.DetachPixelData());
      await encoder.FlushAsync();
      outStream.Dispose();
      return storageFile;
    }
