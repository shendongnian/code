    public class PersonViewModel
    {
       Person _person = new Person(); 
       public string PasswordUser {get;set;}
       public string PasswordConfirm {get;set;}   
    
      public string Name 
      {
         get{ return _person.Name};      //I assume Person has a Name property
         set {_person.Name = value; }
      }
      
      ...
      ....
    
    }
