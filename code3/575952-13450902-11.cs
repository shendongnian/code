    using (FileStream plainTextFile = new FileStream(tmpFile, FileMode.Open, FileAccess.Read))
    {
        var reader = new MyXmlReader(plainTextFile);
        result = (SomeObject)serializer.Deserialize(reader); 
    }
    public class MyXmlReader : XmlTextReader
    {
        public MyXmlReader(Stream s) : base(s)
        {
        }
        public override string ReadString()
        {
            string text =  base.ReadString();
            string newText = String.Join("", text.Where(c => !char.IsControl(c)));
            return newText;
        }
    }
