     [Serializable]
        class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }
        [Serializable]
        class Address
        {
            public string City { get; set; }
        }
 
    static public void SerializeToXML(Person p, Address add)
            {
                IFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(@"C:\data.xml", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, p);
                    formatter.Serialize(stream, add);
                }
            }
            static void DeserializeFromXML()
            {
                IFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(@"C:\data.xml", FileMode.Open, FileAccess.Read, FileShare.None))
                {
                   
                    Person p = (Person)formatter.Deserialize(stream);
                    Address add = (Address)formatter.Deserialize(stream);
                }
            }
