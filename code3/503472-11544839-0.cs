      public static T DeserializeObject<T>(string xml)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return (T)xs.Deserialize(memoryStream);
            }
  
    private static Byte[] StringToUTF8ByteArray(string pXmlString)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] byteArray = encoding.GetBytes(pXmlString);
                return byteArray;
            }
