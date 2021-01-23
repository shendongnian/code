     var request = CreateBaseRequest(body);
            HttpWebResponse WebResp = (HttpWebResponse)request.GetResponse();
            Stream Answer = WebResp.GetResponseStream();
            StreamReader response = new StreamReader(Answer);
            var r = response.ReadToEnd();
     static HttpWebRequest CreateBaseRequest(string postData)
        {
            var req = (HttpWebRequest)HttpWebRequest.Create(@"https://xyz.com/");
            req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            req.Method = "POST";
            req.KeepAlive = true;
            byte[] buffer = Encoding.ASCII.GetBytes(postData);
            req.ContentLength = buffer.Length;
            Stream PostData = req.GetRequestStream();
            PostData.Write(buffer, 0, buffer.Length);
            PostData.Close();
            return req;
        }
