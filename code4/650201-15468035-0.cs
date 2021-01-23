    public class Document
    {
        public static Document Create(Stream input)
        {
            var doc = new XmlDocument();
            doc.Load(input);
            return new Document(doc);
        }
        public class Function
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public Function(XmlNode node)
            {
                Name = node.Attributes["name"].ToString();
                Id = node.Attributes["id"].ToString();
            }
            // Return values
            // Parameters
        }
        public List<Function> Functions { get; set; }
        public Document(XmlDocument doc)
        {
            Functions = new List<Function>();
            var list = doc.GetElementsByTagName("functionlist");
            XmlNode root = list[0];
            XmlNodeList children = root.ChildNodes;
            foreach (var child in children)
            {
                Functions.Add(new Function(child));
            }
        }
    }
