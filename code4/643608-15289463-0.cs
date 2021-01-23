    public static string GetPageHTML(string link)
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(link);
            }
        }
        catch (WebException ex)
        {
            var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
            return "An error occurred, status code: " + statusCode;
        }
    }
