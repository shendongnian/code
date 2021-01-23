    try
    {
        string myString;
        using (WebClient wc = new WebClient())
            myString= wc.DownloadString("http://foo.com");
    
    }
    catch (WebException ex)
    {
        if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
        {
            var resp = (HttpWebResponse)ex.Response;
            if (resp.StatusCode == HttpStatusCode.NotFound) // HTTP 404
            {
                //the page was not found, continue with next in the for loop
                continue;
            }
        }
        //throw any other exception - this should not occur
        throw;
    }
