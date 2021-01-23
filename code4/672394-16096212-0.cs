    class PersonAgeComparer : IComparer<Person>
    {
        public Int32 Compare(Person x, Person y)
        {                
            if (x.Age > y.Age) return 1;
            if (x.Age < y.Age) return -1;
            return 0; // must be equal
        }
    }
    class Person
    {
        public Int32 Age { get; set; }
    }
    
    static void Run1()
    {
        Random rnd = new Random((Int32)DateTime.Now.Ticks);
        List<Person> persons = new List<Person>();
        for (Int32 i = 0; i < 100000; i++)
        {
            persons.Add(new Person() { Age = rnd.Next(100) });
        }
        persons.Sort(new PersonAgeComparer());
        // The oldest but you may have dups (same age)
        Person oldest = persons[persons.Count - 1];
    }
