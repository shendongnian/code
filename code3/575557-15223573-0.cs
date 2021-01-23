     private static void Main(string[] args)
        {
            string result = Serialize(new SIMModel
                {
                    Product = new Product
                        {
                            Items = new List<Item>
                                {
                                    new Item
                                        {
                                            ID = "N",
                                            Name = "N-1",
                                            Child_Item = new Child_Item {ID = "N-1-1"}
                                        }
                                }
                        }
                });
            Console.WriteLine(result);
        }
        
        public static string Serialize<T>(T value)
        {
            if (value == null)
            {
                return null;
            }
            //Create our own namespaces for the output
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        
            //Add an empty namespace and empty value
            ns.Add("", "");
        
            XmlSerializer serializer = new XmlSerializer(typeof (T));
        
            XmlWriterSettings settings = new XmlWriterSettings
                {
                    Encoding = new UnicodeEncoding(false, false),
                    Indent = true,
                    OmitXmlDeclaration = true
                };
        
            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, value, ns);
                }
                return textWriter.ToString();
            }
        }
