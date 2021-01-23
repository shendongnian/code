    string loginSite(string url, string username, string password)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                string cookie = "";
                //this values will change depending on the website
                string values = "vb_login_username=" + username + "&vb_login_password=" + password
                                    + "&securitytoken=guest&"
                                    + "cookieuser=checked&"
                                    + "do=login";
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = values.Length;
                CookieContainer a = new CookieContainer();
                req.CookieContainer = a;
                System.Net.ServicePointManager.Expect100Continue = false; // prevents 417 error
                using (StreamWriter writer = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII)) { writer.Write(values); }
                HttpWebResponse c = (HttpWebResponse)req.GetResponse();
                Stream ResponseStream = c.GetResponseStream();
                StreamReader LeerResult = new StreamReader(ResponseStream);
                string Source = LeerResult.ReadToEnd();
     
                
                foreach (Cookie cook in c.Cookies) { cookie = cookie + cook.ToString() + ";"; }
                return cookie;
            }  
