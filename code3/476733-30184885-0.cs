    WebClient client = new WebClient();
            client.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error == null && !e.Cancelled)
                {
                    //completed.TrySetResult(true);
                    MessageBox.Show("Internet Connected", "True", MessageBoxButton.OK);
                }
                else
                {
                    //completed.TrySetResult(false);
                    MessageBox.Show("Internet Not Connected", "False", MessageBoxButton.OK);
                }
            };
            client.DownloadStringAsync(new Uri("http://www.google.com/"));
