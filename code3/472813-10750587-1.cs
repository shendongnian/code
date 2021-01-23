    public string GetConnectionString()
        {
            string SqlConString1 = value;//Read from config
            string SqlConString2 = value;//Read from config
            WebClient client = new WebClient();
            try
            {
                using (client.OpenRead("http://www.google.com"))
                {
                }
                return SqlConString1 ;
            }
            catch (WebException)
            {
                return SqlConString2 ;
            }
        }
