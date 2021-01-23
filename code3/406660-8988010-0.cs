    var webRequest = (HttpWebRequest)WebRequest.Create(uri);
    webRequest.Method = "PUT";
    webRequest.Headers.Add("DataServiceVersion", "2.0;NetFx");
    webRequest.Headers.Add("MaxDataServiceVersion", "2.0;NetFx");
    webRequest.Headers.Add("x-ms-version", "2011-08-18");
    webRequest.ContentType = @"application/atom+xml";
    TableRequest.SignRequestForSharedKeyLite(webRequest, credentials);
    WriteToRequestStream(uri, webRequest);
    var response = webRequest.GetResponse();
