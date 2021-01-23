        public static XDocument MethodTwo()
        {
            WebResponse response = MethodOne();
            if (response == null)
            {
                response null;
            }
            try
            {
                var stream = response.GetResponseStream();
                XmlReader xmlReader = XmlReader.Create(stream);
                return XDocument.Load(xmlReader);
            }
            finally
            {
                response.Dispose();
            }
        }
