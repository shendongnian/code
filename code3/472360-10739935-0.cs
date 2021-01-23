    public class myTag
    {
        [XmlAttribute]
        public string attr;
        [XmlText]
        public string text;
        public Anchor a;
    }
    [XmlRoot("a")]
    public class Anchor
    {
        [XmlAttribute]
        public string href;
        [XmlText]
        public string text;
    }
-
    var obj = new myTag() { 
        attr = "tag", 
        text = "this is text", 
        a = new Anchor() { 
            href = "http://yaplex.com",
            text="link in the same element" 
        } 
    }; 
            
    XmlSerializer ser = new XmlSerializer(typeof(myTag));
    StringWriter wr = new StringWriter();
    XmlWriter writer = XmlTextWriter.Create(wr, new XmlWriterSettings() { OmitXmlDeclaration = true });
    var ns = new XmlSerializerNamespaces();
    ns.Add("","");
    ser.Serialize(writer,obj, ns);
    string result = wr.ToString();
