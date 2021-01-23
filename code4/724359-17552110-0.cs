        private static void CacheGetDataUrl(Guid sessionGuid)
        {
            var tokens = Driver.GetDataPostValues();
            foreach (var token in tokens)
            {
                try
                {
                    var buffer = Encoding.UTF8.GetBytes(token.Replace("session_identifier", sessionGuid.ToString()));
                    var request = (HttpWebRequest)WebRequest.Create(GetDataUrl);
                    request.KeepAlive = false;
                    request.Timeout = System.Threading.Timeout.Infinite;
                    request.ProtocolVersion = HttpVersion.Version10;
                    request.Method = "POST";
                    request.ContentType = "application/json; charset=utf-8";
                    request.ContentLength = buffer.Length;
                    request.ServicePoint.ConnectionLimit = 250;
                    using (var postData = request.GetRequestStream())
                    {
                        postData.Write(buffer, 0, buffer.Length);
                        postData.Close();
                    }
                    request.Abort();
                    Console.WriteLine("Response requested for URL {0}", GetDataUrl); 
                    Log.Info(String.Format("Response requested for URL {0} using parameters \r\n{1}", GetDataUrl, token));
                }
                catch (Exception)
                {
                    Console.WriteLine("Error occurred requesting response for URL {0} using parameters \r\n{1}", GetDataUrl, token);
                    Log.Error(String.Format("Error occurred requesting response for URL {0} using parameters \r\n{1}", GetDataUrl, token));
                }
            }
        }
