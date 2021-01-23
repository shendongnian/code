        const string url = "http://api.actitudfem.com/register.json";
        string postData = "appid=SomeUniqueID";
        var dataBytes = Encoding.UTF8.GetBytes(postData);
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentLength = dataBytes.Length;
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        using (var postStream = request.GetRequestStream())
            postStream.Write(dataBytes, 0, dataBytes.Length);
        string json = String.Empty;
        using (var response = (HttpWebResponse)request.GetResponse())
        {
            using (var sr = new StreamReader(response.GetResponseStream()))
                json = sr.ReadToEnd();
        }
