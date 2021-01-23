    public static bool IsAlive(string url)
    {
        bool isAlive = false;
        using (WebClient client = new WebClient())
        {
            try
            {
                var content = client.DownloadString(url);
                // if we got this far there was no error fetching the content
                isAlive = true;
            }
            catch (WebException ex)
            {
                // could not fetch page - can output reason here if required
                Console.WriteLine("Error when fetching {0}: {1}", url, ex);
            }
            
        }
        
        return isAlive;
    }
