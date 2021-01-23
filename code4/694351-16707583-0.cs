        public static string ToXML(this object obj)
        {
            var settings = new XmlWriterSettings { Indent = true };
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamReader reader = new StreamReader(memoryStream))
            using(XmlWriter writer = XmlWriter.Create(memoryStream, settings))
            {
                DataContractSerializer serializer = 
                  new DataContractSerializer(obj.GetType());
                serializer.WriteObject(writer, obj);
                writer.Flush();
                memoryStream.Position = 0;
                return reader.ReadToEnd();
            }
        }
