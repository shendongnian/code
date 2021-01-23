        WebClient client = new WebClient();
        try
        {
            client.DownloadStringCompleted += (object newSender, DownloadStringCompletedEventArgs e) =>
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        try
                        {
                            var response = e.Result;
                            // your response logic.
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Problem occured");
                        }
                    });
                };
        }
        catch
        {
            MessageBox.Show("Problem occured");
        }
        finally
        {
            if (userHasCanceled)
                client.DownloadStringAsync(new Uri("xyz"));
        }
        client.DownloadStringAsync(new Uri("abc"));
