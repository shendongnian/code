            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                WebProxy proxy = new WebProxy("your proxy host IP", port);
                client.Proxy = proxy;
                string sourceUrl = "xxxxxx";
                try
                {
                    using (Stream stream = client.OpenRead(new Uri(noaaSourceUrl)))
                    {
                        //......
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
