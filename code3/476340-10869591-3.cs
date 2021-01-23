        var imageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(
             filename, CreationCollisionOption.ReplaceExisting);
        var fs = await imageFile.OpenAsync(FileAccessMode.ReadWrite);
        DataWriter writer = new DataWriter(fs.GetOutputStreamAt(0));
        writer.WriteBytes(await response.Content.ReadAsByteArrayAsync());
        await writer.StoreAsync();
        writer.DetachStream();
        await fs.FlushAsync();
