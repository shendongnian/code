    wc.OpenReadCompleted += ((s, args) =>
    {
        using (var store = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if (store.FileExists(fileName))
                store.DeleteFile(fileName);
            using (var fs = new IsolatedStorageFileStream(fileName, FileMode.Create, store))
            {
                byte[] bytesInStream = new byte[args.Result.Length];
                args.Result.Read(bytesInStream, 0, (int)bytesInStream.Length);
                fs.Write(bytesInStream, 0, bytesInStream.Length);
                fs.Flush();
            }
        }
    });
