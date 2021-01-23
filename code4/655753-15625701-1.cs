    public async Task WriteDataToFileAsync(string fileName, string content)
    {
        byte[] data = Encoding.Unicode.GetBytes(content);
        var folder = ApplicationData.Current.LocalFolder;
        var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        using (var s = await file.OpenStreamForWriteAsync())
        {
            await s.WriteAsync(data, 0, data.Length);
        }
    }
    public async Task<string> ReadFileContentsAsync(string fileName)
    {
        var folder = ApplicationData.Current.LocalFolder;
        try
        {
            var file = await folder.OpenStreamForReadAsync(fileName);
            using (var streamReader = new StreamReader(file))
            {
                return streamReader.ReadToEnd();
            }
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }
