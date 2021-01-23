        public static XDocument MethodTwo()
        {
            using (var response = MethodOne())
            using (var stream = response.GetResponseStream())
            {
                var stream = response.GetResponseStream();
                XmlReader xmlReader = XmlReader.Create(stream);
                return XDocument.Load(xmlReader);
            }
        }
        public static Stream MethodOne()
        {
            Uri uri = new Uri(url, true);
            WebRequest request = WebRequest.Create(uri);
            request.Method = "GET";
            return request;
        }
