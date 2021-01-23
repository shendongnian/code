    using (WebClient client = new WebClient())
    {
        try
        {
            string data = client.DownloadString(
                "http://your-url.com");
            // successful...
        }
        catch (WebException ex)
        {
            // failed...
            using (StreamReader r = new StreamReader(
                ex.Response.GetResponseStream()))
            {
                string responseContent = r.ReadToEnd();
                // ... do whatever ...
            }
        }
    }
