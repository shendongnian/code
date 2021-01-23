        private void POST(string url, string data)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            req.Method = "POST";
            req.Headers.Add(HttpRequestHeader.AcceptLanguage, "de-DE,de;q=0.8,en-US;q=0.7,en;q=0.3");
            req.Timeout = req.ReadWriteTimeout = 15000;
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] dataBytes = encoding.GetBytes(data);
            req.ContentLength = dataBytes.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(dataBytes, 0, dataBytes.Length);
            stream.Close();
            req.GetResponse();
        }
