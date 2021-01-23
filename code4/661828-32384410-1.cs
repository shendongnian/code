    public static byte [] downloadSharepointFile (string url){
          using (var client = new WebClient { Credentials = new NetworkCredential("username", "password", "domain") })
              {
                   client.Headers.Add("Accept: application/json");
                   return client.DownloadData(url);
              }
    }
