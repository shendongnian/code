    public string uriRead(string uri)
    {
      WebClient client = new WebClient();
      client.Credentials = CredentialCache.DefaultCredentials;      
      return client.DownloadString(new Uri(uri));
    }
