    public async void Test(string url)
    {
        string page = await new WebClient().DownloadStringTaskAsync(url);
        //Continue your work after BG thread has finished its work.
    }
