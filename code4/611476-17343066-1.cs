    string url = "http://google.co.in"; 
    IWebProxy proxy = new WebProxy("your proxy server address", port number ); // port number is of type integer 
            proxy.Credentials = new NetworkCredential("your user name", "your password");
    
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
