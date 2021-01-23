    public class Entity
    {
       public int Id { get; set; }
       
    
       public void Method()
       {
          // some code
       }
    }
    
    public class Person : Entity
    {
       public string Name { get; set; }
       
       public void AnotherMethod()
       {
          // some code
       }
    }
    
    public class User : Person
    {
       public string Password { get; set; }
       
       public bool CheckUser(string name, string passworkd)
       {
          // some code
       }
    }
