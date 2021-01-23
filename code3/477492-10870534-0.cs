    private static bool UriExit(Uri uri)
    {
        try
        {
            var request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "HEAD";
            var response = request.GetResponse() as HttpWebResponse;
            return (response.StatusCode == HttpStatusCode.OK);
        }
        catch
        {
            return false;
        }
    }
