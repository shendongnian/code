    var httpWebRequest = (HttpWebRequest)WebRequest.Create("");
    httpWebRequest.ContentType = "text/json";
    httpWebRequest.Method = "POST";
    
    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
        string json = new JavaScriptSerializer().Serialize(new
                    {
                        user = "Foo",
                        password = "Baz"
                    });
        
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
        
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
        }
    }
