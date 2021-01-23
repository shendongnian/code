        String targetUrl = "https://www.SomeUrlThatRequiresAuthentication.com";
        HttpWebRequest request = GetNewRequest(targetUrl);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        while (response.StatusCode ==  HttpStatusCode.MovedPermanently)
        {
            response.Close();
            request = GetNewRequest(response.Headers["Location"]);
            response = (HttpWebResponse)request.GetResponse();
        }
    private static HttpWebRequest GetNewRequest(string targetUrl)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUrl);
        request.AllowAutoRedirect = false;
        request.Headers.Add("Authorization", "Basic xxxxxxxx");
        return request;
    }
