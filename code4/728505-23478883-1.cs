        HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
        myHttpWebRequest.Method = "POST";
        myHttpWebRequest.ContentType = "application/json; encoding=utf-8";
        using (var streamWriter = new StreamWriter(myHttpWebRequest.GetRequestStream()))
        {
            string json = "{user:\"user1\",pass:\"pass1\"}";
            streamWriter.Write(json);
            streamWriter.Flush();
        }
        var httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            responsebody = streamReader.ReadToEnd();
        }
