    public class Person : IPerson
    {
        public string Name { get; set;} 
        public int Age { get; set;}
    
        public Person(string name, int age)
        {
           this.Name = name;
           this.Age = age;
        }
    }
