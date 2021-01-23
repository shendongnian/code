    Public static void SavePersons(List<Person> Persons)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(IEnumerable(Person));
      // Create a FileStream to write with.
      using(Stream writer = new FileStream(filename, FileMode.Create))
      {
            serializer.Serialize(writer, persons);
      }
    }
