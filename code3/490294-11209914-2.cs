    // Callback used to validate the certificate in an SSL conversation
    private static bool ValidateRemoteCertificate(
        object sender,
        X509Certificate certificate,
        X509Chain chain,
        SslPolicyErrors policyErrors)
    {
        if (Convert.ToBoolean(ConfigurationManager.AppSettings["IgnoreSslErrors"]))
        {
            // Allow any old dodgy certificate...
            return true;
        }
        else
        {
            return policyErrors == SslPolicyErrors.None;
        }
    }
    private static string MakeRequest(string uri, string method, WebProxy proxy)
    {
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
        webRequest.AllowAutoRedirect = true;
        webRequest.Method = method;
        // Allows for validation of SSL conversations
    ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(
        ValidateRemoteCertificate);
        if (proxy != null)
        {
            webRequest.Proxy = proxy;
        }
        HttpWebResponse response = null;
        try
        {
            response = (HttpWebResponse)webRequest.GetResponse();
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        finally
        {
            if (response != null)
                response.Close();
        }
    }
