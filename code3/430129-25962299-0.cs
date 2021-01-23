    string url = @"http://restcountries.eu/rest/v1";
    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IEnumerable<RootObject>));
    WebClient syncClient = new WebClient();
    string content = syncClient.DownloadString(url);
    using (MemoryStream memo = new MemoryStream(Encoding.Unicode.GetBytes(content)))
    {
        IEnumerable<RootObject> countries = (IEnumerable<RootObject>)serializer.ReadObject(memo);    
    }
    Console.Read();
