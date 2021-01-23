    req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.CookieContainer = cookieContainer;
            req.Method = "POST";
            req.ContentType = "text/json";
            byte[] byteArray2 = Encoding.ASCII.GetBytes(body);
            req.ContentLength = byteArray2.Length;
            Stream newStream = req.GetRequestStream();
            newStream.Write(byteArray2, 0, byteArray2.Length);
            newStream.Close();
