        public string getHtmltt(string url)
        {
            string responseData = "";
            try
            {
                string host = string.Empty;
                if (url.Contains("/search?"))
                {
                    host = url.Remove(url.IndexOf("/search?"));
                    
                    if(host.Contains("//"))
                    {
                        host = host.Remove(0, host.IndexOf("//")).Replace("//","").Trim();
                    }
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.AllowAutoRedirect = true;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                request.Timeout = 60000;
                request.Method = "GET";
                request.KeepAlive = false; ;
               // request.Host = "www.google.com.af";
                request.Host = host;
                request.Headers.Add("Accept-Language", "en-US");
                
                //request.Proxy = null;
               // WebProxy prx = new WebProxy("199.231.211.107:3128");
                
                WebProxy prx = new WebProxy(proxies[0].ToString().Trim());
                request.Proxy = prx;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(responseStream);
                    responseData = myStreamReader.ReadToEnd();
                }
                foreach (Cookie cook in response.Cookies)
                {
                    inCookieContainer.Add(cook);
                }
                response.Close();
            }
            catch (System.Exception e)
            {
                responseData = "An error occurred: " + e.Message;
            }
            return responseData;
        }
