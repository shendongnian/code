    class Data {
        public DateTime Date { get; set; }
        public int Code { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
    static void Main() {
        var sb = new StringBuilder();
        var xws = new XmlWriterSettings();
        xws.OmitXmlDeclaration = true;
        xws.Indent = false;
        var elements = new[] {
            new Data { Date = DateTime.Now, First = "Hello", Last = "World", Code = 2}
        ,   new Data { Date = DateTime.UtcNow, First = "Quick", Last = "Brown", Code = 4}
        };
        using (var xw = XmlWriter.Create(sb, xws)) {
            xw.WriteStartElement("root");
            foreach (var d in elements) {
                xw.WriteStartElement("i");
                xw.WriteAttributeString("t", ""+d.Date);
                xw.WriteAttributeString("a", "" + d.Code);
                xw.WriteElementString("u", d.First);
                xw.WriteElementString("s1", d.Last);
                xw.WriteEndElement();
            }
            xw.WriteEndElement();
        }
        Console.WriteLine(sb.ToString());
    }
