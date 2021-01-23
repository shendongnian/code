        public static string SerializeObjectToXml<T>(T obj)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            xmlSerializer.Serialize(xmlTextWriter, obj);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            string xmlString = ByteArrayToStringUtf8(memoryStream.ToArray());
            xmlTextWriter.Close();
            memoryStream.Close();
            memoryStream.Dispose();
            return xmlString;
        }
