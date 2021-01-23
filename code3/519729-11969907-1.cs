    Public static void SavePersons(Persons persons)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Persons));
      // Create a FileStream to write with.
      using(Stream writer = new FileStream(filename, FileMode.Create))
      {
            serializer.Serialize(writer, persons);
      }
    }
