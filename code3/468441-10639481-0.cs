    using (var fs = await file.OpenAsync(FileAccessMode.ReadWrite))
    {
        using (var outStream = fs.GetOutputStreamAt(0))
        {
            using (var dataWriter = new DataWriter(outStream))
            {
                byte[] buffer = new byte[4096];
                dataWriter.WriteBytes(buffer)
                await dataWriter.StoreAsync();
                dataWriter.DetachStream();
            }
            await outStream.FlushAsync();
        }
    }
