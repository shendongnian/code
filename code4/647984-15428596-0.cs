        public static IEnumerable<Url> GetRewriteXML()
        {
            XDocument xml =
                    XDocument.Load(HttpContext.Current.Server.MapPath(fileName));
            var xmlSerializer = new XmlSerializer(typeof(Url));
            
            var nodes = xml.Descendants("RewriteRule")
                    .Select(rr => xmlSerializer.Deserialize(rr.CreateReader()) as Url);
            return nodes;
        }
