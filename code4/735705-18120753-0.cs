    StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync(strFileName, Windows.Storage.CreationCollisionOption.ReplaceExisting);
    public async Task Receive(byte[] buffer)
    {
      using (var ostream = await file.OpenStreamForWriteAsync())
      {
         await ostream.WriteAsync(buffer, 0, buffer.Length);
      }
    }
