    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(HostURI);
    request.Method = "GET";
    String test = String.Empty;
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        test = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
     }
     DeserializeObject(test ...)
