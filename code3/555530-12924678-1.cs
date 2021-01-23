    public static string SerializeToString(object obj)
            {
                var serializer = new XmlSerializer(obj.GetType());
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                var ms = new MemoryStream();
                //the following line omits the xml declaration
                var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Encoding = new UnicodeEncoding(false, false) };
                var writer = XmlWriter.Create(ms, settings);
                serializer.Serialize(writer, obj, ns);
                return Encoding.Unicode.GetString(ms.ToArray());
            }
