    var boundary = string.Format("----------{0:N}", Guid.NewGuid());
    System.IO.MemoryStream content = new MemoryStream();
    var writer = new StreamWriter(content);
    foreach (var att in attachments)
    {
    
        writer.WriteLine("--{0}", boundary);
        writer.WriteLine("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"", "file", Path.GetFileName(att["filename"]));
        writer.WriteLine("Content-Type: {0}", att.ContentType);
        writer.WriteLine();
        writer.Flush();
        att.Stream.CopyTo(content);
        writer.WriteLine();
    }
    writer.WriteLine("--" + boundary + "--");
    writer.Flush();
    content.Seek(0, SeekOrigin.Begin);
    
    
    HttpWebRequest oRequest = null;
    oRequest = (HttpWebRequest)HttpWebRequest.Create(string.Format(RestBaseURI + "issue/{0}/attachments", item.Key));
    oRequest.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
    oRequest.Method = "POST";
    oRequest.Headers.Add("Authorization", AuthData);
    oRequest.Headers.Add("X-Atlassian-Token", "nocheck");
    oRequest.UseDefaultCredentials = true;
    oRequest.KeepAlive = true;
    oRequest.ContentLength = content.Length;
    
    using (var oStream = oRequest.GetRequestStream())
    {
        content.CopyTo(oStream);
    }
    
    using (var oResponse = (HttpWebResponse)oRequest.GetResponse())
    {
        using (var reader = new StreamReader(oResponse.GetResponseStream()))
        {
            var responseData = reader.ReadToEnd();
            var data = JObject.Parse(responseData);
        }
    }
