    private string requestByProxy(string url)
    {
        string responseString, proxyAddress;
        while (responseString == null)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                // set properties, headers, etc
                proxyAddress = getNextProxy();
                if (proxyAddress == null)
                    throw new Exception("No more proxies");
                request.Proxy = new WebProxy(proxyAddress);
                request.Timeout = 15 * 1000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                responseString = sr.ReadToEnd();
            }
            catch (WebException wex)
            {
                continue;
            }
        }
        return responseString;
    }
