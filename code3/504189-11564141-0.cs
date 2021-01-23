        var _plainText = string.Empty;
        var _request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
        _request.Timeout = 5000;
        _request.Method = "GET";
        _request.ContentType = "text/plain";
        using (var _webResponse = (HttpWebResponse)_request.GetResponse())
        {
            var _webResponseStatus = _webResponse.StatusCode;
            var _stream = _webResponse.GetResponseStream();
            using (var _streamReader = new StreamReader(_stream))
            {
                _plainText = _streamReader.ReadToEnd();
            }
        }
