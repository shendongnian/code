    var url = string.Format
    (
        "https://www.googleapis.com/calendar/v3/calendars?key={0}",
        application.Key
    );
    var httpWebRequest = HttpWebRequest.Create(url) as HttpWebRequest;
    httpWebRequest.Headers["Authorization"] = 
        string.Format("Bearer {0}", user.AccessToken.Token);                    
    httpWebRequest.Method = "POST";
    // added the character set to the content-type as per David's suggestion
    httpWebRequest.ContentType = "application/json; charset=UTF-8";
    httpWebRequest.CookieContainer = new CookieContainer();
    // replaced Environment.Newline by CRLF as per David's suggestion
    var requestText = string.Join
    (
        "\r\n",
        "{",
        " \"summary\": \"Test Calendar 123\"",
        "}"
    );
    using (var stream = httpWebRequest.GetRequestStream())
    // replaced Encoding.UTF8 by new UTF8Encoding(false) to avoid the byte order mark
    using (var streamWriter = new StreamWriter(stream, new UTF8Encoding(false)))
    {
        streamWriter.Write(requestText);
    }
