    public class MyClass
    {
      IPerson person;
    
      public MyClass(IPerson p)
      {
        person = p; // injected an instance of IPerson to MyClass
      }
    
      // can now use person in any method of the class, or pass it around:
    
      public void MyMethod()
      {
         string name = person.Name;
      }
    }
