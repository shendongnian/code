    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public void Save()
        {
            Database.SavePerson(Name, Address);
        }
        public static void Save(string name, string address)
        {
            Database.SavePerson(name, address);
        }
    }
