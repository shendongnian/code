    public static string Extract(string yahooHttpRequestString)
    {
          //if need to pass proxy using local configuration  
          System.Net.WebClient webClient = new WebClient();  
          webClient.Proxy = HttpWebRequest.GetSystemWebProxy();  
          webClient.Proxy.Credentials = CredentialCache.DefaultCredentials;  
          Stream strm = webClient.OpenRead(yahooHttpRequestString);  
          StreamReader sr = new StreamReader(strm);  
          string result = sr.ReadToEnd();            
          strm.Close();             
          return result;  
    }  
