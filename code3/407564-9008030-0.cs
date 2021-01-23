        public static string HttpRequest(string requestType, string contentType, string parameters, string URI, CookieContainer cookies)
        {
            string results = string.Empty;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URI);
            req.CookieContainer = cookies;
            req.Method = requestType;
            req.AllowAutoRedirect = true;
            req.ContentLength = 0;
            req.ContentType = contentType;
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:5.0) Gecko/20100101 Firefox/5.0";
            if (!string.IsNullOrEmpty(parameters))
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
                req.ContentLength = byteArray.Length;
                Stream dataStream = req.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                if (HttpStatusCode.OK == response.StatusCode)
                {
                    Stream responseStream = response.GetResponseStream();
                    // Content-Length header is not trustable, but makes a good hint.        
                    // Responses longer than int size will throw an exception here!        
                    int length = (int)response.ContentLength;
                    const int bufSizeMax = 65536;
                    // max read buffer size conserves memory        
                    const int bufSizeMin = 8192;
                    // min size prevents numerous small reads        
                    // Use Content-Length if between bufSizeMax and bufSizeMin        
                    int bufSize = bufSizeMin;
                    if (length > bufSize) bufSize = length > bufSizeMax ? bufSizeMax : length;
                    // Allocate buffer and StringBuilder for reading response        
                    byte[] buf = new byte[bufSize];
                    StringBuilder sb = new StringBuilder(bufSize);
                    // Read response stream until end        
                    while ((length = responseStream.Read(buf, 0, buf.Length)) != 0)
                        sb.Append(Encoding.UTF8.GetString(buf, 0, length));
                    results = sb.ToString();
                }
                else
                {
                    results = "Failed Response : " + response.StatusCode;
                }
            }
            catch (Exception exception)
            {
                Log.Error("WebHelper.HttpRequest", exception);
            }
            return results;
        }
