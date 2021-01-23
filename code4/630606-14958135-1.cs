        public static string Serialize(T obj)
        {
            if (obj == null)
                return string.Empty;
            // XML-Serialisieren in String
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            // Serialisieren in MemoryStream
            MemoryStream ms = new MemoryStream();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(ms, settings);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            serializer.Serialize(writer, obj, namespaces);
            // Stream in String umwandeln 
            StreamReader r = new StreamReader(ms);
            r.BaseStream.Seek(0, SeekOrigin.Begin);
            return r.ReadToEnd();
        }        
        public static T DeSerialize(string txt)
        {
            T retVal = default(T);
            if (string.IsNullOrEmpty(txt))
            {
                return retVal;
            }
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof (T));
                StringReader stringReader = new StringReader(txt);
                XmlTextReader xmlReader = new XmlTextReader(stringReader);
                retVal = (T) ser.Deserialize(xmlReader);
                xmlReader.Close();
                stringReader.Close();
            }
            catch (Exception)
            {
            }
            return retVal;
        }        
    }
