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
        parameter.SqlDbType = SqlDbType.NVarChar;
        parameter.Direction = ParameterDirection.Input;     
        parameter.Value = P.fName; 
    } 
