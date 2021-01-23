    var tmpFile= await ApplicationData.Current.
                           LocalFolder.CreateFileAsync
                             ("tmp.txt", CreationCollisionOption.ReplaceExisting);
    using (var writer = new StreamWriter(await tmpFile.OpenStreamForWriteAsync()))
    {
        await writer.WriteAsync("File content");
    }
    var operationResult = 
          await client.BackgroundUploadAsync(folderId, tmpFile.Name, tmpFile,
                                              OverwriteOption.Overwrite);
