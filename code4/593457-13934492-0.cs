        private void POST(string url, string data)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            req.Method = "POST";
            req.Headers.Add(HttpRequestHeader.AcceptLanguage, "de-DE,de;q=0.8,en-US;q=0.7,en;q=0.3");
            req.Timeout = req.ReadWriteTimeout = 15000;
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] DataBytes = encoding.GetBytes(data);
            req.ContentLength = DataBytes.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(DataBytes, 0, DataBytes.Length);
            stream.Close();
            req.GetResponse();
        }
