    static public void SerializeToXML(College college)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(college));
      TextWriter textWriter = new StreamWriter(@"C:\college.xml");
      serializer.Serialize(textWriter, college);
      textWriter.Close();
    }
