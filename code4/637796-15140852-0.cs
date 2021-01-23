    static void Main(string[] args)
        {
            WriteContacts(new List<Contact>( new []{ new Contact { ID = 1, Name = "Juan", Age = 34 }, new Contact { Name = "Pedro", Age = 23, ID = 2 } }));
            FindContactInFile("Juan");
            FindContactInFile("Mario");
            Console.ReadKey();
        }
        private static void FindContactInFile(string name)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream s = new FileStream("contacts.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var contacts = (List<Contact>)formatter.Deserialize(s);
                var person  = contacts.Where(x=>x.Name==name).FirstOrDefault();
                if (person != null)
                    Console.WriteLine("Persona encontrada: {0}", person.Name);
                else
                    Console.WriteLine("{0} no fue encontrado en el archivo.", name);
            }
        }
        private static void WriteContacts(List<Contact> contacts)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream s = new FileStream("contacts.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(s, contacts);
            }
        }
    }
    [Serializable]
    class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
