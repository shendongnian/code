    public static bool CheckExists(string url)
    {
       Uri uri = new Uri(url);
       if (uri.IsFile) // File is local
          return System.IO.File.Exists(uri.LocalPath);
       try
       {
          HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
          request.Method = "HEAD"; // No need to download the whole thing
          HttpWebResponse response = request.GetResponse() as HttpWebResponse;
          return (response.StatusCode == HttpStatusCode.OK); // Return true if the file exists
       }
       catch
       {
          return false; // URL does not exist
       }
    }
