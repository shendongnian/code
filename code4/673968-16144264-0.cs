    private IEnumerable<string> CountPictures(int from, int to, string folder)
    {
        for (int i = from; i < to; i++)
            yield return string.Format("{0}/image{1}.jpg", folder, i.ToString("D2"));
    }
    private async Task ImportImages()
    {
        HttpClient c = new HttpClient();
        int count = 0;
        c.BaseAddress = new Uri("http://www.cs.washington.edu/research/imagedatabase/groundtruth/", UriKind.Absolute);
        foreach (var pic in CountPictures(1, 48, "leaflesstrees"))
        {
            var pic_response = await c.GetAsync(pic, HttpCompletionOption.ResponseContentRead);
            if (pic_response.IsSuccessStatusCode)
            {
                await SaveImageAsync(pic.Replace('/', '_'), await pic_response.Content.ReadAsStreamAsync());
                Debug.WriteLine(pic + " imported");
                count++;
            }
        }           
        Debug.WriteLine(string.Format("{0} images imported", count));
    }
    private Task SaveImageAsync(string filename, Stream stream)
    {
        var task = Task.Factory.StartNew(() =>
        {
            if (stream == null || filename == null)
            {
                throw new ArgumentException("one of parameters is null");
            }
            try
            {
                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream targetStream = isoStore.OpenFile(filename, FileMode.Create, FileAccess.Write))
                    {
                        byte[] readBuffer = new byte[4096];
                        int bytesRead = -1;
                        stream.Position = 0;
                        targetStream.Position = 0;
                        while ((bytesRead = stream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        {
                            targetStream.Write(readBuffer, 0, bytesRead);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("DocumentStorageService::LoadImage FAILED " + e.Message);
            }
        });
        return task;
    }
