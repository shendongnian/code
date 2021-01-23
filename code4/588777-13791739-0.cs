    interface IPerson 
    {
      string Name {get;}
    }
    
    class Person: IPerson
    {
       string realName;
       public string Name 
       {
         get {return realName;} 
         set {realName=value;}
       }
    }
    
    class FakePerson : IPerson
    {
       public string Name {get {return "Bob";} }
    }
