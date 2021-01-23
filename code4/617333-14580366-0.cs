    Task<bool> newTask;
    private void UploadButton_Click(object sender, RoutedEventArgs e)
    {
        newTask = UploadTask();
    }
    private async Task<bool> UploadTask()
    {
        bool success = false;
        int counter = 0;
        while (counter < 3 && !success)
        {
            Debug.WriteLine("starting upload");
            success = await UploadFileAsync();
            Debug.WriteLine("finished upload. result " + success.ToString());
            if (!success) System.Threading.Thread.Sleep(5000);
            counter++;
        }
        return success;
    }
    private async Task<bool> UploadFileAsync()
    {
        MultipartFormDataContent content = new MultipartFormDataContent();
        var filestream = new FileStream(filePath, FileMode.Open);
        var fileName = System.IO.Path.GetFileName(filePath);
        content.Add(new StreamContent(filestream), "file", fileName);
        content.Add(new StringContent(terminal_id.ToString()), "terminal_id");
        var message = new HttpRequestMessage();
        message.Method = HttpMethod.Post;
        message.Content = content;
        message.RequestUri = new Uri(target_url);
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage res = await client.SendAsync(message);
                if (res.IsSuccessStatusCode) return true;
            }
            catch (HttpRequestException hre)
            {
                Debug.WriteLine(hre.ToString());
            }
            return false;
        }
    }
