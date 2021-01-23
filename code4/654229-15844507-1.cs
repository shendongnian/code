    using System.Xml;
    using XmlParserLibrary;
    
    namespace XmlParserLibraryTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var xmlParser = new XmlParser();
    
                Letter letter;
                using (var reader = XmlReader.Create("Letter.xml"))
                    letter = xmlParser.Parse<Letter>(reader);
            }
        }
    
        public class Letter
        {
            public LetterAssociate Sender { get; set; }
            public LetterAssociate Receiver { get; set; }
            public LetterContent Content { get; set; }
        }
    
        public class LetterAssociate
        {
            public string Name { get; set; }
            public string Address { get; set; }
        }
    
        [XmlParser(typeof(LetterContentXmlParser))]
        public class LetterContent
        {
            public string Header { get; set; }
            public string Body { get; set; }
        }
    
        internal class LetterContentXmlParser : IXmlParser
        {
            public object Parse(XmlReader reader)
            {
                var content = new LetterContent();
    
                while (reader.Read())
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (reader.LocalName)
                            {
                                case "Header":
                                    content.Header = reader.ReadElementContentAsString();
                                    break;
                                case "Body":
                                    content.Body = reader.ReadElementContentAsString();
                                    break;
                            }
                            break;
                    }
    
                return content;
            }
        }
    }
