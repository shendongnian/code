    public string GetExternalIp()
    {
        for (int i = 0; i < 2; i++)
        {
            string res = GetExternalIpWithTimeout(400);
            if (res != "")
            {
                return res;
            }
        }
        throw new Exception("Failed to get external IP");
    }
    private static string GetExternalIpWithTimeout(int timeoutMillis)
    {
        string[] sites = new string[] {
          "http://ipinfo.io/ip",
          "http://icanhazip.com/",
          "http://ipof.in/txt",
          "http://ifconfig.me/ip",
          "http://ipecho.net/plain"
        };
        foreach (string site in sites)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(site);
                request.Timeout = timeoutMillis;
                using (var webResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = webResponse.GetResponseStream())
                    {
                        using (StreamReader responseReader = new System.IO.StreamReader(responseStream, Encoding.UTF8))
                        {
                            return responseReader.ReadToEnd().Trim();
                        }
                    }
                }
            }
            catch
            {
                continue;
            }
        }
        return "";
    }
