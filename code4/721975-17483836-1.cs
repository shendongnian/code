    public class Undergrad
    {
         String fName, lName;
         private static int _uniqueID;   
 
         public Undergrad() : this(string.Empty, string.Empty)
         {
    
         }
    
         public Undergrad(string firstName, string lastName) 
         {
             this.fName = firstName;
             this.lName = lastName;          
    
             _uniqueID += 1; 
         }
        public int UniqueID { get { return _uniqueID; } }
    }
