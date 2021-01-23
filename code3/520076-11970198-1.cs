    public class Person
    {
        public string Name { get; set; }
        public float  Bid  { get; set; }
        public Person(string name, float bid)
        {
            Name = name;
            Bid = bid;
        }
    }
    
    public class Persons : List<Person>
    {
        public void Fill()
        {
            Add(new Person("Bob", 19.15);
            Add(new Person("Alice" , 28.20);
            Add(new Person("Michael", 25.12);
        }
    }
