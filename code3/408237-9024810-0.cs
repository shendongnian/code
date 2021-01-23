    I think you should pass the values through the class to webservice. And you can extract values from the class and send to the database query. This will give you more efficiency over adding and removing parameters.
    Eg. 
    fun ServiceCall()
    {
    Person P
    P.fName='First Name'
    p.lName='Last Name'
      serviceClas.setData(P)
    }
    public string setData(Person p)    
     { 
    //insert firstname and last name to database 
    
    SqlCommand command = new SqlCommand();    
    SqlCommand command = new SqlCommand  ("Proc_name", connection);      
    command.CommandType = CommandType.StoredProcedure;    
    SqlParameter parameter1 = new SqlParameter();    
    parameter.ParameterName = "@Param1";     
    parameter.SqlDbType = SqlDbType.NVarChar;     parameter.Direction = ParameterDirection.Input;     
    parameter.Value = P.fName; 
    } 
