    public class XMLPlayground
    {
        public void Play()
        {
            List<b> list = new List<b>()
            {    
                new b() {a = "Name"}, 
                new b() {a = "Age"}, 
            };
            string str = SerializeToString(list);
            Console.WriteLine(str); 
        }
        private string SerializeToString(object o)
        {
            if (o == null) return "";
            var xs = new XmlSerializer(o.GetType());
            XmlSerializerNamespaces tellTheSeriliserToIgnoreNameSpaces = new XmlSerializerNamespaces();
            tellTheSeriliserToIgnoreNameSpaces.Add(String.Empty, String.Empty);
            XmlWriterSettings tellTheWriterToOmitTheXmlDeclaration = new XmlWriterSettings { OmitXmlDeclaration = true };
            using (StringWriter writer = new StringWriter())
            {
                using (var xw = XmlWriter.Create(writer, tellTheWriterToOmitTheXmlDeclaration))
                {
                    xs.Serialize(xw, o, tellTheSeriliserToIgnoreNameSpaces);
                    return writer.ToString();
                }
            }
        }
    }
    [Serializable]
    public class b
    {
        public string a { get; set; }
    }
