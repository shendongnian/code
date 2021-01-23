    public XmlDocument SendRequest(string command, string request)
    {
        if (!IsInitialized())
            return null;
        var result = new XmlDocument();
        try
        {
            var prefix = (m_SecureMode) ? "https://" : "http://";
            var url = string.Concat(prefix, m_Url, command);
            var webRequest = (HttpWebRequest) WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "text/xml";
            webRequest.ServicePoint.Expect100Continue = false;
            var UsernameAndPassword = string.Concat(m_Username, ":", m_Password);
            var EncryptedDetails = Convert.ToBase64String(Encoding.ASCII.GetBytes(UsernameAndPassword));
            webRequest.Headers.Add("Authorization", "Basic " + EncryptedDetails);
            using (var requestStream = webRequest.GetRequestStream())
            {
                using (var sw = new StreamWriter(requestStream))
                {
                    sw.WriteLine(request);
                }
            }
            using (var webResponse = webRequest.GetResponse())
            {
                using (var responseStream = webResponse.GetResponseStream())
                {
                    result.Load(responseStream);
                }
            }
        }
        catch (Exception ex)
        {
            result.LoadXml("<error></error>");
            result.DocumentElement.InnerText = ex.ToString();
        }
        return result;
    }
