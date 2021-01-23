    MemoryStream m = new MemoryStream();
    MyWriter xmlWriter = new MyWriter(m);
            
    XDocument xDoc = XDocument.Parse(xml);
    xDoc.Save(xmlWriter);
    xmlWriter.Flush();
    string s = Encoding.UTF8.GetString(m.ToArray());
-
    public class MyWriter : XmlTextWriter
    {
        public MyWriter(Stream s) : base(s,Encoding.UTF8)
        {
        }
        public override void WriteString(string text)
        {
            base.WriteRaw(HttpUtility.HtmlEncode(text));
        }
    }
