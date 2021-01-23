    string serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(entity);
    HttpWebRequest request = WebRequest.CreateHttp(storeUrl);
    request.Method = "PUT";
    request.AllowWriteStreamBuffering = false;
    request.ContentType = "application/json";
    request.Accept = "Accept=application/json";
    request.SendChunked = false;
    request.ContentLength = serializedObject.Length;
    using (var writer = new StreamWriter(request.GetRequestStream()))
    {
        writer.Write(serializedObject);
    }
    var response = request.GetResponse() as HttpWebResponse;
