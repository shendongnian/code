    public class Customer : IEntity
    {
       public decimal CustomerID {get; set;}
       [NotMapped]
       public int Id 
       { 
          get { return (int)CustomerID; }
          set { CustomerID = (int)value; } 
       }
       public string FirstName { get; set; }
       public string LastName { get; set; }
    }
