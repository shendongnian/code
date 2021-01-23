    var client = new WebClient();
    client.DownloadStringCompleted += (sender, e) =>
    {
        try
        {
            if (e.Error == null)
            {
                Console.WriteLine(e.Result);
            }
        }
        finally
        {
            ((WebClient)sender).Dispose();
        }
    };
    client.DownloadStringAsync(new Uri("http://www.google.com"));
