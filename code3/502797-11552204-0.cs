        public static XElement GetXElementFromObject<T>(T objectToSerialize)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var doc = new XDocument();
            using (XmlWriter xmlWriter = doc.CreateWriter())
            {
                xmlSerializer.Serialize(xmlWriter, objectToSerialize);
            }
            return doc.Root;
        }
