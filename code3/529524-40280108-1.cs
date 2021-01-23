    Stream stream = actionContext.Request.Content.ReadAsStreamAsync().Result;
    Encoding encoding = Encoding.UTF8;
    stream.Position = 0;
    string responseData = "";
    
    using (StreamReader reader = new StreamReader(stream, encoding))
    {
        responseData = reader.ReadToEnd().ToString();
    }
    
    var dic = JsonConvert.DeserializeObject<IDictionary<string, string>>(responseData);
