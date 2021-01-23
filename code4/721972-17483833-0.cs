    public class Undergrad
    {
         String fName, lName;
         public Guid UniqueId {get; set; }
    
         public Undergrad()
         {
              UniqueId = System.Guid.NewGuid();
         }
    
         public Undergrad(string firstName, string lastName)
         {   
             UniqueId = System.Guid.NewGuid();
             this.fName = firstName;
             this.lName = lastName;           
         }
    }
