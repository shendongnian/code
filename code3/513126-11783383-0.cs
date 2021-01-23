    public Class Customer
    {
              
      [NotMapped]
      public bool MyColumnBool 
      {
          get
          {
             return (MyColumn ==1);
          }
      }
      public int MyColumn {get; set;}
      // other properties
    
    }
