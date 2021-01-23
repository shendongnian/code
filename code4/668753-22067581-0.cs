    private static byte[] DownloadFile(string absoluteUrl)
    {
       using (var client = new System.Net.WebClient())
       {
          return client.DownloadData(absoluteUrl);
       }
    }
    
