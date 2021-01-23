    [Serializable]
    [System.Xml.Serialization.XmlRoot("RewriteRule")]
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
        public Url(Url url)
        {
            url.From = this.From;
            url.To = this.To;
            url.StatusCode = this.StatusCode;
        }
    }
