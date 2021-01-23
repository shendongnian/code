     public class SerializeDeserialize<T>
        {
            StringBuilder sbData;
            StringWriter swWriter;
            XmlDocument xDoc;
            XmlNodeReader xNodeReader;
            XmlSerializer xmlSerializer;
            public SerializeDeserialize()
            {
                sbData = new StringBuilder();
            }
            public string SerializeData(T data)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(T));
                swWriter = new StringWriter(sbData);
                employeeSerializer.Serialize(swWriter, data);
                return sbData.ToString();
            }
    
            public T DeserializeData(string dataXML)
            {
                xDoc = new XmlDocument();
                xDoc.LoadXml(dataXML);
                xNodeReader = new XmlNodeReader(xDoc.DocumentElement);
                xmlSerializer = new XmlSerializer(typeof(T));
                var employeeData = xmlSerializer.Deserialize(xNodeReader);
                T deserializedEmployee = (T)employeeData;
                return deserializedEmployee;
            }
        }
