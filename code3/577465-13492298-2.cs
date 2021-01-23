    private void CallTwoWebServices()
    {
        var client = new WebClient();
        client.DownloadStringCompleted += (s, e) =>
        {
            //1st call completed. Now make 2nd call.
            var client2 = new WebClient();
            client2.DownloadStringCompleted += (s2, e2) =>
            {
                //Both calls completed.
            };
            client2.DownloadStringAsync(new Uri("http://www.google.com/"));
        };
        client.DownloadStringAsync(new Uri("http://www.microsoft.com/"));
    }
