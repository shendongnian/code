     public static string GetContent(string uri)
     {
         using (WebClient client = new WebClient())
         {
             // Pretend to be IE6
             client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
             return client.DownloadString(uri);
          }
      }
