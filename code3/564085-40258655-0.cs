    LoginInfo obj = new LoginInfo();
    
    obj.username = uname;
    obj.password = pwd;
    var parameters = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
    
    var req = WebRequest.Create(uri);
    
    req.Method = "POST";
    req.ContentType = "application/json";
    
    byte[] bytes = Encoding.ASCII.GetBytes(parameters);
    
    req.ContentLength = bytes.Length;
    
    using (var os = req.GetRequestStream())
    {
        os.Write(bytes, 0, bytes.Length);
    
        os.Close();
    }
    
    var stream = req.GetResponse().GetResponseStream();
    
    if (stream != null)
        using (stream)
        using (var sr = new StreamReader(stream))
        {
            return sr.ReadToEnd().Trim();
        }
