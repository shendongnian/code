            WebClient client = new WebClient();
            client.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error != null && !string.IsNullOrEmpty(e.Result))
                {
                    XDocument doc = XDocument.Load(e.Result);
                }
            };
            client.DownloadStringAsync(new Uri("http://mylocation.com/myfile.php?userid=xyz"));
