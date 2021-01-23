       static readonly XmlWriterSettings ws = new XmlWriterSettings()
        {
            OmitXmlDeclaration = true,
            Encoding = System.Text.Encoding.UTF8
        };
        static XElement ToXElement<T>(T obj)
        {
            StringBuilder sb = new StringBuilder();
            Type valorType = obj.GetType();
            using (var writer = XmlDictionaryWriter.Create(sb, ws))
            {
                DataContractSerializer s = new DataContractSerializer(typeof(T));
                s.WriteObject(writer, obj);
                writer.Flush();
                writer.Close();
            }
            return XElement.Parse(sb.ToString());
        }
        static T ToObj<T>(XElement node)
        {
            string xml = node.ToString(SaveOptions.DisableFormatting);      
            T respuesta = default(T);
            DataContractSerializer dcs = new DataContractSerializer(typeof(T));
            using (StringReader strReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = new XmlTextReader(strReader))
                {
                    respuesta = (T)dcs.ReadObject(xmlReader, false);
                }
            }
            return respuesta;
        }
        
