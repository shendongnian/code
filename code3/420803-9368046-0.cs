    public static string SerializeToString(object obj)
    {
       using (var serializer = new XmlSerializer(obj.GetType()))
       using (var writer = new StringWriter())
       {
          serializer.Serialize(writer, obj);
          return writer.ToString();
       }
    }
