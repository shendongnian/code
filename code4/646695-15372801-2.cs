    public static bool CheckExists(string url)
    {
       try
       {
          HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
          request.Method = "HEAD"; // No need to download the whole thing
          HttpWebResponse response = request.GetResponse() as HttpWebResponse;
          return (response.StatusCode == HttpStatusCode.OK); // Return true if the file exists
       }
       catch
       {
          return false; // URL does not exist
       }
    }
