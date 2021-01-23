        static void Main(string[] args)
        {
                Person p = new Person();
                p.FirstName = "Mike";
                p.LastName = "Smith";
                p.Age = 33;
                Console.WriteLine("List of properties in the Person class");
                foreach (var pInfo in typeof (Person).GetProperties())
                {
                    Console.WriteLine("\t"+ pInfo.Name);
                }
                Console.WriteLine("Type in name of property for which you want to get the value and press enter.");
                var property = Console.ReadLine();
                p.displayInfo(property);
        }
        
        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public UInt16 Age { get; set; }
            public Person()
            {
                FirstName = "";
                LastName = "";
                Age = 0;
            }
            public void displayInfo(string property)
            {
                // Note this will throw an exception if property is null 
                Console.WriteLine(property + ": " + this.GetType().GetProperty(property).GetValue(this, null));
                Console.ReadKey();
            }
        }
