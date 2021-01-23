    public static string JsonPost(string url, string method, string postData)
    {
        Uri address = new Uri(url + method);
        //Get User current network credential
        ICredentials credentials = CredentialCache.DefaultCredentials;
        NetworkCredential credential = credentials.GetCredential(address, "Basic");
        HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
        request.Method = "POST";
        request.ContentType = "application/json";
        //Network Credential should be included on the request to avoid network issues when requesting to the web service
        request.Proxy = WebRequest.DefaultWebProxy;
        request.Credentials = new NetworkCredential(credential.UserName, credential.Password, credential.Domain);
        request.Proxy.Credentials = new NetworkCredential(credential.UserName, credential.Password, credential.Domain);
        byte[] byteData = UTF8Encoding.UTF8.GetBytes(postData);
        request.ContentLength = byteData.Length;
        using (Stream postStream = request.GetRequestStream())
        {
            postStream.Write(byteData, 0, byteData.Length);
        }
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JsonResponse = reader.ReadToEnd();
            return JsonResponse;
        }
    }
