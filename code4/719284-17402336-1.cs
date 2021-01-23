    public class Person   
    {
      private string firstName;
      private string lastName;
    
      public string FirstName
      {   
            get { return this.firstName; }  
            set { this.firstName = value.ToLower();}
      }
    
      public string LastName
      {   
            get { return this.lastName; }  
            set { this.lastName = value.ToLower();}
      }
    }
