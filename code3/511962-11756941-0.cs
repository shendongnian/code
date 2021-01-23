    StringWriter stringWriter = new StringWriter();
    MyWriter xmlWriter = new MyWriter(stringWriter);
            
    XDocument xDoc = XDocument.Parse(xml);
    xDoc.Save(xmlWriter);
    xmlWriter.Flush();
    string s = stringWriter.ToString();
-
    public class MyWriter : XmlTextWriter
    {
        public MyWriter(StringWriter wr) : base(wr)
        {
        }
        public override void WriteString(string text)
        {
            base.WriteRaw(HttpUtility.HtmlEncode(text));
        }
    }
