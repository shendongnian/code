    public async Task<StorageFile> GetBingMapImage(string ImageUrl)
    {
        StorageFile storageFile = null;
        HttpClient httpClient = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, ImageUrl);
        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var fileSavePicker = new FileSavePicker();
            fileSavePicker.FileTypeChoices.Add("png", new List<string> { ".png" });
            fileSavePicker.SuggestedFileName = "map.png";
            fileSavePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            storageFile = await fileSavePicker.PickSaveFileAsync();
    
            if (storageFile != null)
            {
                IRandomAccessStream randomAccessStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);
                DataWriter dataWriter = new DataWriter(randomAccessStream.GetOutputStreamAt(0uL));
                var bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                dataWriter.WriteBytes(bytes);
                await dataWriter.StoreAsync();
                await dataWriter.FlushAsync();
                await randomAccessStream.FlushAsync();
                dataWriter.Dispose();
                randomAccessStream.Dispose();
            }
        }
        return storageFile;
    }
