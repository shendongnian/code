        var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, Windows.Storage.CreationCollisionOption.ReplaceExisting);
        using (var fs = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
        {
            var outStream = fs.GetOutputStreamAt(0);
            var dataWriter = new Windows.Storage.Streams.DataWriter(outStream);
            dataWriter.WriteString("Hello from Test!");
            await dataWriter.StoreAsync();
            dataWriter.DetachStream();
            await outStream.FlushAsync();
            outStream.Dispose(); // 
            fs.Dispose();
        }
