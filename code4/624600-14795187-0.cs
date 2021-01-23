    public async Task<string> DownloadFileAsync(Uri uri, string filename)
    {
        using (var fileStream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(filename, CreationCollisionOption.ReplaceExisting))
        {
            var webStream = await new HttpClient().GetStreamAsync(uri);
            await webStream.CopyToAsync(fileStream);
            webStream.Dispose();
        }
        return (await ApplicationData.Current.LocalFolder.GetFileAsync(filename)).Path;
    }
