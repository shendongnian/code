    public class Class1
    {
        public XDocument GetXml()
        {
            return XDocument.Parse(Resources.config);
        }
    }
