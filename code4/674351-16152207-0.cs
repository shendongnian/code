    public IReadOnlyPerson
    {
        string Name {get;}
        string Age {get;}
    }
    public class Person : IReadOnlyPerson
    {
        public string Name { get; set;} 
        public int Age { get; set;}
    
        public Person(string Name, int Age)
        {
           this.Name = Name;
           this.Age = Age;
        }
    }
