    class PersonDataContext
    {
        public PersonDataContext()
        {
            Console.WriteLine("In PersonDataContext Constructor");
        }
    }
    class Data
    {
        PersonDataContext persons = new PersonDataContext();
        public Data() 
        {
            Console.WriteLine("In Data Contructor");
        }
    }
    
    class Data2
    {
        PersonDataContext persons;
        public Data2() 
        {
            Console.WriteLine("In Data2 Constructor");
            persons = new PersonDataContext();
        }
    }
