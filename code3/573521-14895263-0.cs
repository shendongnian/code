    public class XmlCustomTextWriter : XmlTextWriter
    {
        private TextWriter _tw = null;
        public XmlCustomTextWriter(TextWriter sink)
            : base(sink)
        {
            _tw = sink;
            Formatting = Formatting.Indented;
            Indentation = 0;
        }
        public void OutputElement(string name, string value)
        {
            WriteStartElement(name);
            string nl = _tw.NewLine;
            _tw.NewLine = "";
            WriteString(value);
            WriteFullEndElement();
            _tw.NewLine = nl;
        }
    }
