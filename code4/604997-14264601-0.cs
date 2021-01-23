    public static void HttpsRequest(string address)
    {
      string data;
       HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
       request.Method = "GET";
       using (WebResponse response = request.GetResponse())
      {
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            data = reader.ReadToEnd();
        }
      }
    }
