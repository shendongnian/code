    if (sqlDataReader.Read())
    {    
        String roles = sqlDataReader[0].ToString();
        return roles;
    }
    else
    {
        // The user name or password is incorrect; return something else or throw an exception.
    }
