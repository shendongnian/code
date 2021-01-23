        private bool WebFileExists(string url)
        {
            bool exists = true;
            try
            {
                using (WebClient testClient = new WebClient())
                {
                    testClient.Credentials = new NetworkCredential(_userName, _password);
                    Stream stream = testClient.OpenRead(url);
                    stream.Dispose();
                }
            }
            catch
            {
                exists = false;
            }
            return exists;
        }
