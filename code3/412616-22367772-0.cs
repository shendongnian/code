    var request = (HttpWebRequest)WebRequest.Create("http://url");
    request.ContentType = "text/json";
    request.Method = "POST";
    
    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
    {
        string json = new JavaScriptSerializer().Serialize(new
                    {
                        user = "Foo",
                        password = "Baz"
                    });
        
        streamWriter.Write(json);
    }
        
    var response = (HttpWebResponse)request.GetResponse();
    using (var streamReader = new StreamReader(response.GetResponseStream()))
    {
            var result = streamReader.ReadToEnd();
    }
