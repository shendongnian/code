     private string firstName;
     public string FirstName
     {
        get
        {
            return firstName;
        }
        set
        {
            firstName = (value=="mycheck")?"default":value;
        }
     }
