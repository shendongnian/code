     class Person
     {
    
        public Person(string name)
        {
           this.myName = name;
        }
    
        private string myName ="N/A";
        public string Name
        {
            get 
            {
               return myName; 
            }
            private set 
            {
               myName = value; 
            }
        }
    
        public override string ToString()
        {
            return "Name = " + Name;
        }
    
        public static void Main()
        {
            Person person = new Person("Joe");
            Console.WriteLine("Person details - {0}", person);
            Console.WriteLine("Person details - {0}", person);
    
        }
     }
