    public class Undergrad
    {
         String fName, lName;
    
         public Undergrad() : this(string.Empty, string.Empty)
         {
    
         }
    
         public Undergrad(string firstName, string lastName) 
         {
             this.fName = firstName;
             this.lName = lastName;          
    
             UniqueID += 1; 
         }
        public static int UniqueID { get; private set; }
    }
