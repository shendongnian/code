    public class Person
    {
       public string Name { get; set; }
    
       public Person(string name)
       {
            Name = name;
       }
    
       public string SayName()
       {
          string hello = "Hello! My name is ";
          return hello + name;
       }
    }
    Person p = new Person("John");
    string yourName = p.SayName();
