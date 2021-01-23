    try
    {
        using(SqlConnection conn = new SqlConnection(connString))
        {
            // Some code for when "conn" is succesfully instantiated
        }
    }
    catch (SomeSpecificConnectionInstantiationException ex)
    {
        // Use ex to handle a bizarre instantiation exception?
    }       
