    public class ComboData
    {
        public ComboData(string sString)
        {
            xdoc = new XmlDocument();
            xdoc.LoadXml(sString);
        }
        public XmlDocument xdoc { get; set; }
    }
