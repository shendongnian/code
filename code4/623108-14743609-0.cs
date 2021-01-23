    public class Program
    {
        public static void Main(string[] args)
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Entity",new XAttribute("Type", "attribute1")));
            
            StringBuilder builder = new StringBuilder();
            using (TextWriter writer = new EncodingStringWriter(builder, Encoding.UTF8))
            {
                xDoc.Save(writer);
            }
            
            Console.WriteLine(builder.ToString());
        }
    }
    
    public class EncodingStringWriter : StringWriter
    {
        private readonly Encoding _encoding;
        
        public EncodingStringWriter(StringBuilder builder, Encoding encoding) : base(builder)
        {
            _encoding = encoding;
        }
        
        public override Encoding Encoding
        {
            get { return _encoding;  }                
        }
    }
