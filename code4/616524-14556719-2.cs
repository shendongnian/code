        private void button1_Click(object sender, EventArgs e)
        {
            var objCookieContainer = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://website.com/login.php?user=xxx&pass=xxx");
            request.Method = WebRequestMethods.Http.Get;
            request.Timeout = 15000;
            request.Proxy = null;
            request.CookieContainer = objCookieContainer;
            HttpWebRequest newRequest = (HttpWebRequest)WebRequest.Create("http://website.com/page.php?link=url");
            newRequest.Method = WebRequestMethods.Http.Post;
            newRequest.Timeout = 15000;
            newRequest.Proxy = null;
            
            HttpWebResponse response = null;
            response = (HttpWebResponse)request.GetResponse();
            //once you read response u need to add all cookie sent in header to the 'objCookieContainer' so that it can be forwarded on second response
            foreach (Cookie cookie in response.Cookies)
            {
                objCookieContainer.Add(cookie);
            }
            string readerRequest = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            //since you have added the cookies, this must response fine now
            newRequest.CookieContainer = objCookieContainer;
            response = (HttpWebResponse)newRequest.GetResponse();
            string readerNewRequest = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
