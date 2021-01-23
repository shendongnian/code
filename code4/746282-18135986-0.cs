    Uri _uri = new Uri("http://localhost:8081/Test.asmx");
    WebClient wcClient = new WebClient();
    NameValueCollection nvcKeys = new NameValueCollection();
    wcClient.Headers.Add("Cache-Control", "no-cache");
    wcClient.Headers.Add("User-Agent", "Test Service 1.0");
    wcClient.Headers.Add(nvcKeys);
    wcClient.UploadStringAsync(_uri, "POST", "Hello World");
