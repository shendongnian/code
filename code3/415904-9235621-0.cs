    public static string ToXml<T>(T obj)
    {
       using (var ms = new MemoryStream())
       using (var sr = new StreamReader(ms))
       {
           var xmlSer = new XmlSerializer(typeof(T));
           xmlSer.Serialize(ms, obj);
           ms.Seek(0, SeekOrigin.Begin);
           return sr.ReadToEnd();
       }
    }
