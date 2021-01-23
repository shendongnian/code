    string formParams = string.Format("user={0}&password={1}&switch=Log+In", username, password);
                WebRequest req = WebRequest.Create(Login_Page_URL);
                req.ContentType = "application/x-www-form-urlencoded";
                req.Method = "POST";
                req.Proxy.Credentials = CredentialCache.DefaultCredentials;
                byte[] bytes = Encoding.ASCII.GetBytes(formParams);
                req.ContentLength = bytes.Length;
                using (Stream os = req.GetRequestStream())
                {
                    os.Write(bytes, 0, bytes.Length);
                }
                resp = req.GetResponse();
                cookieHeader = resp.Headers["Set-cookie"];
                resp.Close();
    // to view the page behing login page
    
                WebRequest getRequest = WebRequest.Create(Page_Behing_login_Page_URL);
                getRequest.Headers.Add("Cookie", cookieheader);
                WebResponse getResponse = getRequest.GetResponse();
                using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
                {
                    pageSource = sr.ReadToEnd();
                }
