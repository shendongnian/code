     //Serialize
     public static string SerializeObject<T>(object o) 
     {
            MemoryStream ms = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(T));
            XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF32);
            xs.Serialize(xtw, o);
            ms = (MemoryStream)xtw.BaseStream;
            UTF32Encoding encoding = new UTF32Encoding();
            return encoding.GetString(ms.ToArray());
     }
     //Deserialize
     public static T DeserializeObject<T>(string xml) 
     {
           XmlSerializer xs = new XmlSerializer(typeof(T));
           UTF32Encoding encoding = new UTF32Encoding();
           Byte[] byteArray = encoding.GetBytes(xml);
           MemoryStream ms = new MemoryStream(byteArray);
           XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF32);
           return (T)xs.Deserialize(ms);
     }
 
