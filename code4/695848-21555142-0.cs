            private static string RunWebRequest(string url, string json)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // Header
            request.ContentType = "application/json";
            request.Method = "POST";
            request.AllowAutoRedirect = false;
            request.KeepAlive = false;
            request.Timeout = 30000;
            request.ReadWriteTimeout = 30000;
            request.UserAgent = "test.net";
            request.Accept = "application/json";
            request.ProtocolVersion = HttpVersion.Version11;
            request.Headers.Add("Accept-Language","de_DE");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            request.ContentLength = bytes.Length;
            using (var writer = request.GetRequestStream())
            {
                writer.Write(bytes, 0, bytes.Length);
                writer.Flush();
                writer.Close();
            }
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var jsonReturn = streamReader.ReadToEnd();
                return jsonReturn;
            }
        }
        
       
