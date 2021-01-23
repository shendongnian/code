        private class GoogleShortenedURLResponse
        {
            public string id { get; set; }
            public string kind { get; set; }
            public string longUrl { get; set; }
        }
        private class GoogleShortenedURLRequest
        {
            public string longUrl { get; set; }
        }
        public ActionResult Index1()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShortenURL(string longurl)
        {
            string googReturnedJson = string.Empty;
            JavaScriptSerializer javascriptSerializer = new JavaScriptSerializer();
            GoogleShortenedURLRequest googSentJson = new GoogleShortenedURLRequest();
            googSentJson.longUrl = longurl;
            string jsonData = javascriptSerializer.Serialize(googSentJson);
            byte[] bytebuffer = Encoding.UTF8.GetBytes(jsonData);
            WebRequest webreq = WebRequest.Create("https://www.googleapis.com/urlshortener/v1/url");
            webreq.Method = WebRequestMethods.Http.Post;
            webreq.ContentLength = bytebuffer.Length;
            webreq.ContentType = "application/json";
            using (Stream stream = webreq.GetRequestStream())
            {
                stream.Write(bytebuffer, 0, bytebuffer.Length);
                stream.Close();
            }
            using (HttpWebResponse webresp = (HttpWebResponse)webreq.GetResponse())
            {
                using (Stream dataStream = webresp.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        googReturnedJson = reader.ReadToEnd();
                    }
                }
            }
            //GoogleShortenedURLResponse googUrl = javascriptSerializer.Deserialize<googleshortenedurlresponse>(googReturnedJson);
            //ViewBag.ShortenedUrl = googUrl.id;
            return View();
        }
