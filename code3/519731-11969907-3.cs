    Public static void SavePersons(Persons persons)
    {
      var serializer = new DataContractSerializer(typeof(Persons));
      // Create a FileStream to write with.
      FileStream fs = new FileStream("file.xml", FileMode.Create);
      using (fs)
      {
         ser.WriteObject(fs, p);
      }
    }
