    var request = WebRequest.Create (uri);
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    request.Headers.Add("X-HTTP-Method-Override", "GET");
    var body = StringBuilder();
    body.Append("key=SECRET");
    body.AppendFormat("&source={0}", HttpUtility.UrlEncode(source));
    body.AppendFormat("&target={0}", HttpUtility.UrlEncode(target));
    body.AppendFormat("&q=", HttpUtility.UrlEncode(text));
    var bytes = Encoding.ASCII.GetBytes(body.ToString());
    if (bytes.Length > 5120) throw new ArgumentOutOfRangeException("text");
    request.ContentLength = bytes.Length;
    using (var output = request.GetRequestStream())
    {
        output.Write(bytes, 0, bytes.Length);
    }
    
