    public class Gateway
    {
     public string DoSomethingWithPerson(IPerson person)
     {
        return person.DoSomething();
     }
    }
    //then IPerson implementors like Student can provide the custom behaviour.
    public class Student : Person
    {
      public string DoSomething()
      { 
          return "Go Away!";
      }
      ...
    }
