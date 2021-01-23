    static public void SerializeToXML(MyData data)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(MyData));
      TextWriter textWriter = new StreamWriter(@"C:\data.xml");
      serializer.Serialize(textWriter, data);
      textWriter.Close();
    }
