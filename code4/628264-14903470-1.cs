     public  string getHtml(string url)
        {
            string responseData = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "*/*";
                request.AllowAutoRedirect = true;
                request.UserAgent = "http_requester/0.1";
                request.Timeout = 60000;
                request.Method = "GET";
                request.CookieContainer=yummycookies;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(responseStream);
                    responseData = myStreamReader.ReadToEnd();
                }
                response.Close();
            }
            catch (Exception e)
            {
                responseData = "An error occurred: " + e.Message;
            }
            return responseData;
        }
