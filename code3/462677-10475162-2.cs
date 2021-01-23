    public Values LoadValues(Stream stream)
    {
       XmlSerializer serializer = new XmlSerializer(typeof(Values));
       using (TextReader textReader = new StreamReader(stream))
       {
          return (Values)serializer.Deserialize(textReader);
       }
    }
