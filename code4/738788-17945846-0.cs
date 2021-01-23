            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.KeepAlive = true;
            CookieContainer cookies = new CookieContainer(); // instantiate cookie container
            request.CookieContainer = cookies;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            // Calculate control number...
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string data = @"id=" + id + "&controlNumber=" + controlNumber;
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
            request.ContentLength = dataStream.Length;
            request.CookieContainer = cookies;
            Stream newStream = request.GetRequestStream();
            newStream.Write(dataStream, 0, dataStream.Length);
            newStream.Close();
            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());
            string html = sr.ReadToEnd();
