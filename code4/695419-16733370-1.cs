    [XmlRoot(ElementName = "RootXML")]
    public class Apply
    {
        private string _testAttr="dfdsf";
     
        [XmlAttribute]
        public String TestAttr
        {
            get { return _testAttr; }
            set { _testAttr = value; }
        }
    }
