    public class Person
    {
        public Person(string name,string lastName )
        {
            Name = name;
            LastName = lastName;
        }
    
        public Person(string name, string lastName,string address):this(name,lastName)
        {
            //you don't need to set again Name and Last Name
            //as you can call the other constructor that does the job
            Address = Address;
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
