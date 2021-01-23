      public static T DeserializeXml<T>(Stream stream, XmlRootAttribute root)
      {
                XmlSerializer deserializer = new XmlSerializer(typeof(T), root);
                return (T)deserializer.Deserialize(stream);
      }
 
