    var timer = Stopwatch.StartNew();
    var url = "http://sandbox.api.shopping.com/publisher/3.0/rest/GeneralSearch?apiKey=78b0db8a-0ee1-4939-a2f9-d3cd95ec0fcc&trackingId=7000610&keyword=nikon";
    var webRequest = WebRequest.Create(url);
    webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
    using (var webResponse = webRequest.GetResponse())
    using (var responseStream = webResponse.GetResponseStream())
    using (var streamReader = new StreamReader(responseStream))
    {
        var content = streamReader.ReadToEnd();
    }
    var timeSpan = timer.Elapsed;
    Console.WriteLine(timeSpan);
