    public static UrlCollection GetRewriteXML(string fileName)
        {
            XDocument xml = XDocument.Load(HttpContext.Current.Server.MapPath(fileName));
            var urls = from s in xml.Descendants("RewriteRule")
                       select new
                       {
                           From = (string)s.Element("From").Value,
                           To = (string)s.Element("To").Value,
                           StatusCode = (string)s.Element("Type").Value
                       };
            UrlCollection nodes = new UrlCollection();
            foreach (var url in urls)
            {
                nodes.Add(new Url(url.From, url.To, url.StatusCode));
            }
            return nodes;
        }
    [Serializable]
    public class Url
    {
        [XmlElement("From")]
        public string From { get; set; }
        [XmlElement("To")]
        public string To { get; set; }
        [XmlElement("Type")]
        public string StatusCode { get; set; }
        public Url()
        {
        }
        public Url(string From, string To, string StatusCode)
        {
            this.From = From;
            this.To = To;
            this.StatusCode = StatusCode;
        }
        public Url(Url url)
        {
            url.From = this.From;
            url.To = this.To;
            url.StatusCode = this.StatusCode;
        }
    }
