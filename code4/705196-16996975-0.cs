    var row =LoadProfile().Tables[0].Rows[0];
    
    string? firstName = row.Field<string?>( "FirstName" );
    string? lastName= row.Field<string?>( "LastName" );
    
    if ((System.DateTime.Now.Hour < 12) && (!string.IsNullOrEmpty(lastName)))
    {
         return "Good Morning " + firstName + " " + lastName;
    }
    else
    {
          return "Good Morning";
    }
