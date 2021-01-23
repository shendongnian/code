    private void testMethod() 
    {
        string sqlString = .....
    
        //here should be the code, which will create sql parameters
        // An varchar(80) parameter called @Name with the value "Chuck".
        SqlParameter paramName = new SqlParameter("@Name", SqlDbType.VarChar, 80);
        paramName.Value = "Chuck";
    
        // An int parameter called @Age with the value 49.
        SqlParameter paramAge = new SqlParameter("@Age", SqlDbType.Int);
        paramAge.Value = 49;
        // Create more parameters here, as many as you want.
    
        //and now we call the SetDataSet with all needed arguments:
        SetDataSet(sqlString, paramName, paramAge); // just add all parameters one after another.
    }
