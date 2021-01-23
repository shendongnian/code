    public static void WriteObject(string fileName)
            {
                Console.WriteLine(
                    "Creating a Person object and serializing it.");
                Person p1 = new Person("Zighetti", "Barbara", 101);
                FileStream writer = new FileStream(fileName, FileMode.Create);
                DataContractSerializer ser =
                    new DataContractSerializer(typeof(Person));
                ser.WriteObject(writer, p1);
                writer.Close();
            }
    
            public static void ReadObject(string fileName)
            {
                Console.WriteLine("Deserializing an instance of the object.");
                FileStream fs = new FileStream(fileName,
                FileMode.Open);
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(Person));
    
                // Deserialize the data and read it from the instance.
                Person deserializedPerson =
                    (Person)ser.ReadObject(reader, true);
                reader.Close();
                fs.Close();
                Console.WriteLine(String.Format("{0} {1}, ID: {2}",
                deserializedPerson.FirstName, deserializedPerson.LastName,
                deserializedPerson.ID));
            }
