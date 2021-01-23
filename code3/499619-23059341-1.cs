        public static string Serialize(object dataToSerialize)
        {
            if(dataToSerialize==null) return null;
            using (StringWriter stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(dataToSerialize.GetType());
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
        }
        public static T Deserialize<T>(string xmlText)
        {
            if(String.IsNullOrWhiteSpace(xmlText)) return null;
            using (StringReader stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
        }
