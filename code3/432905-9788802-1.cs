    public class Employee 
     {
            public virtual int Id { get; set; }
    
            public virtual string FirstName { get; set; }
    
            public virtual string LastName { get; set; }
    
            public virtual string MiddleName { get; set; }
     }
    
    public class CreateEmployeeViewModel 
     {
            public virtual string FirstName { get; set; }
    
            public virtual string LastName { get; set; }
    
            public virtual string MiddleName { get; set; }
     }
    
    public class EditEmployeeViewModel : CreateEmployeeViewModel  
     {
            public virtual int Id { get; set; }
     }
