    Task<bool> newTask;
    private void UploadButton_Click(object sender, RoutedEventArgs e)
    {
        newTask = UploadTask();
    }
    private async Task<bool> UploadTask()
    {
    bool success = false;
    int counter = 0;
    // build content to send
    HttpContent content = new MultipartFormDataContent();
    var filestream = new FileStream(filePath, FileMode.Open);
    var fileName = System.IO.Path.GetFileName(filePath);
    content.Add(new StreamContent(filestream), "file", fileName);
    content.Add(new StringContent(terminal_id.ToString()), "terminal_id");
    while (counter < 3 && !success)
    {
        Debug.WriteLine("starting upload");
        success = await UploadFileAsync(content);
        Debug.WriteLine("finished upload. result " + success.ToString());
        counter++;
    }
    return success;
    }
