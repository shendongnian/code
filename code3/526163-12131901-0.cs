    public async void Test1()
    {
          WebClient wc = new WebClient();
          richTextBox1.Text =  await wc.DownloadStringTaskAsync("https://facebook.com");
    }
