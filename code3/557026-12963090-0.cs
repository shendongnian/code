    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Save()
        {
            DB.SavePerson(Name, Address);
        }
        public static Save(string name, string address)
        {
            DB.SavePerson(name, address);
        }
    }
