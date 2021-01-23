        try
        {
                WebClient client = new WebClient();
                client.Proxy = proxy;
                string resp = client.DownloadString(url);
                // more processing code 
                }
            }
        }
        catch (WebException ex)
        {
            MessageBox.Show(ex.ToString()); 
        }
    }
