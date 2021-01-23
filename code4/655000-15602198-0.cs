    var client = new HttpClient();
    var response = await client.GetAsync(uri);
    if (response.IsSuccessStatusCode)
    {
        Stream stream = null;
        StorageFolder localFolder = ApplicationData.Current.TemporaryFolder;
        StorageFile file = await localFolder.CreateFileAsync("savename.htm",
            CreationCollisionOption.ReplaceExisting);
        stream = await file.OpenStreamForWriteAsync();
        await response.Content.CopyToAsync(stream);
