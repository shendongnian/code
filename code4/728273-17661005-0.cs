            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.website.net/login.php");
            request.Method = "POST";
            request.CookieContainer = new CookieContainer();
            byte[] query = Encoding.UTF8.GetBytes("uid=login&pwd=password");
            request.ContentLength = query.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(query,0, query.Length);
            }
            var response = request.GetResponse();
            var str = new StreamReader(response.GetResponseStream()).ReadToEnd();
            HttpWebRequest request2 = (HttpWebRequest)HttpWebRequest.Create("http://www.website.net/index.php");
            request2.Method = "GET";
            request2.CookieContainer = request.CookieContainer;//<-pass cookies
            var response2 = request2.GetResponse();
            var str2 = new StreamReader(response2.GetResponseStream()).ReadToEnd();
