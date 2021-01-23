    var task = await StorageFile.GetFileFromApplicationUriAsync(uri);
    var stream = await task.OpenStreamForReadAsync();
     using (var info = File.Create(new StreamFileAbstraction(Path.GetFileName(uri.LocalPath), stream, stream)))
     {
          Album = info.Tag.Album;
          Comment = info.Tag.Comment;
          // more properties
     }
