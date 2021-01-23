    using (FileStream tmpFileStream = new FileStream(tmpFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
    {
        var writer = new MyXmlWriter(tmpFileStream);
        serializer.Serialize(writer, items);
    }
    public class MyXmlWriter : XmlTextWriter
    {
        public MyXmlWriter(Stream s) : base(s, Encoding.UTF8)
        {
        }
        public override void WriteString(string text)
        {
            string newText = String.Join("", text.Where(c => !char.IsControl(c)));
            base.WriteString(newText);
        }
    }
