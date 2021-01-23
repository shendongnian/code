    public class Person : IComparable<Person> //legal, recursive definition
    {
       //fields (or properties) that are of type Person
       public Person Father;
       public Person Mother;
       public List<Person> Children;
    
       // method that takes a Person as a parameter
       public bool IsParent(Person potentialParent)
       {
          ....
       }
       //method that returs a Person
       public Person Clone()
       {
          //TODO: real implementation coming soon
       }
       public Person(){}
 
       //constructor that takes persons as arguments
       public Person(Person father, Person Mother)
       {
          Father = father;
          Mother = mother;
       }
    }
