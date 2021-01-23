    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    public class InstaCookie
    {
        private CookieCollection mCookieCollection;
        public InstaCookie()
        {           
            // Bootstrap 
            mCookieCollection = new CookieCollection();
            mCookieCollection = Get("https://www.instagram.com/accounts/login/").Cookies;
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Login(string username, string password)
        {
            var data = $"username={username}&password={password}";
            var response = Post("https://www.instagram.com/accounts/login/ajax/", data);
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var rs = streamReader.ReadToEnd();
                // Log
                Console.WriteLine(rs);
                // Store cookie -- Now use can using to make request.
                mCookieCollection.Add(response.Cookies);
            }
        }
       
        /// <summary>
        /// Send get message
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private HttpWebResponse Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.KeepAlive = true;
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:45.0) Gecko/20100101 Firefox/45.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.5");
            // Store cookies
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(this.mCookieCollection);
            return request.GetResponse() as HttpWebResponse;
        }
        /// <summary>
        /// Send post message
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        private HttpWebResponse Post(string url, string postData)
        {
            // Compute data
            byte[] content = Encoding.ASCII.GetBytes(postData);
            // Make rq
            var rq = (HttpWebRequest)WebRequest.Create(url);
            // Option
            rq.Method = "POST";
            rq.ProtocolVersion = HttpVersion.Version11;
            // Headers
            rq.Host = "www.instagram.com";
            rq.KeepAlive = true;
            rq.ContentLength = content.Length;
            rq.Headers.Add("Origin", "https://www.instagram.com");
            rq.Headers.Add("X-Instagram-AJAX", "1");
            rq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:41.0) Gecko/20100101 Firefox/41.0";
            rq.ContentType = "application/x-www-form-urlencoded";
            rq.Accept = "*/*";
            rq.Headers.Add("X-Requested-With", "XMLHttpRequest");
            rq.Headers.Add("X-CSRFToken", mCookieCollection["csrftoken"].Value);
            rq.Referer = "https://www.instagram.com/";
            rq.Headers.Add("Accept-Language", "en -US,en;q=0.5");
            // Need bonus cookie
            rq.CookieContainer = new CookieContainer();
            rq.CookieContainer.Add(this.mCookieCollection);
            // Send request
            Stream requestStream = rq.GetRequestStream();
            requestStream.Write(content, 0, content.Length);
            requestStream.Close();
            // return response
            return rq.GetResponse() as HttpWebResponse;
        }
    }
