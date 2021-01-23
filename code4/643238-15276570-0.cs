    async void GetUrls(IEnumerable<string> urlList)
    {
      foreach (string url in urllist)
      {
        string filename = url.Split('/').Last();
        label3.Text = filename;
        label8.Text = "Download in progress...";
        await webclient.DownloadFileAsync(new Uri(url), @"C:\Users\Krisz" + @"\" + filename);
        counter++;
        label8.Text = "Done!";
      }
    }
