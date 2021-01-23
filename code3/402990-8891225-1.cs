    class MyXmlReader : XmlTextReader
    {
        private bool readingDate = false;
        const string CustomUtcDateTimeFormat = "ddd MMM dd HH:mm:ss Z yyyy"; // Wed Oct 07 08:00:07 GMT 2009
        public MyXmlReader(Stream s) : base(s) { }
        public MyXmlReader(string inputUri) : base(inputUri) { }
        public override void ReadStartElement()
        {
            if (string.Equals(base.NamespaceURI, string.Empty, StringComparison.InvariantCultureIgnoreCase) &&
                (string.Equals(base.LocalName, "lastBuildDate", StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(base.LocalName, "pubDate", StringComparison.InvariantCultureIgnoreCase)))
            {
                readingDate = true;
            }
            base.ReadStartElement();
        }
        public override void ReadEndElement()
        {
            if (readingDate)
            {
                readingDate = false;
            }
            base.ReadEndElement();
        }
        public override string ReadString()
        {
            if (readingDate)
            {
                string dateString = base.ReadString();
                DateTime dt;
                if(!DateTime.TryParse(dateString,out dt))
                    dt = DateTime.ParseExact(dateString, CustomUtcDateTimeFormat, CultureInfo.InvariantCulture);
                return dt.ToUniversalTime().ToString("R", CultureInfo.InvariantCulture);
            }
            else
            {
                return base.ReadString();
            }
        }
    }
