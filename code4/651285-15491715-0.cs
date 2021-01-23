            StringBuilder uri = new StringBuilder();
            uri.Append("https://graph.facebook.com/oauth/access_token?");
            uri.Append("client_id=" + ClientKey + "&");
            uri.Append("redirect_uri=" + Curl + "&");
            uri.Append("scope=offline_access&");
            uri.Append("client_secret=" + ClientSecret + "&");
            uri.Append("code=" + OAuthCode);
            HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            req.Headers.Add("Authorization", header);            
            req.Method = "POST";
            req.ServicePoint.Expect100Continue = false;
            req.ContentLength = 0;
            req.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string result = sr.ReadToEnd().Trim();
                string[] resultCollection = Regex.Split(result, "&");
                string access_token = Regex.Split(resultCollection[0], "=")[1];//This is the access token
                //which you want and you can save it to database or some  where for further use.
            }
            catch (WebException ex)
            {
                resp = (HttpWebResponse)ex.Response;
                //pass on the exception
                throw ex;
            }
