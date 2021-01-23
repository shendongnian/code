    public class User{
      private DateTime added;
      private DateTime? modified;
    
      string FirstName {get;set;}
      string SurName {get;set;}
    
      DateTime AddedDateTime { 
       get { return added; } 
       set { added = value;
             modified = modified ?? value;
           }
       }
    
      DateTime? ModifiedDateTime {
        get { return modified }
        set { modified = value; }
      }
    }
