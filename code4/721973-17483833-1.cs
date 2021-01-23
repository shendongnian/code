    public class Undergrad
    {
         String fName, lName;
         public int UniqueId {get; set; }
    
         public Undergrad()
         {
              UniqueId = //LoadFromDatabase();
         }
    
         public Undergrad(string firstName, string lastName)
         {   
             UniqueId = //LoadFromDatabase();
             this.fName = firstName;
             this.lName = lastName;           
         }
    }
