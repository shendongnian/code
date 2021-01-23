    public class Undergrad
    {
         String fName, lName;
         private static int _uniqueID;   
         private int _myUniqueID;
 
         public Undergrad() : this(string.Empty, string.Empty)
         {
    
         }
    
         public Undergrad(string firstName, string lastName) 
         {
             this.fName = firstName;
             this.lName = lastName;          
    
             _uniqueID += 1; 
             _myUniqueID = _uniqueID;
         }
        public int UniqueID { get { return _myUniqueID; } }
    }
