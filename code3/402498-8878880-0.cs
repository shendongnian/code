     public static T DeserializeObject<T>(string xml) 
     {
           XmlSerializer xs = new XmlSerializer(typeof(T));
           UTF32Encoding encoding = new UTF32Encoding();
           Byte[] byteArray = encoding.GetBytes(xml);
           MemoryStream ms = new MemoryStream(byteArray);
           XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF32);
           return (T)xs.Deserialize(ms);
     }
 
