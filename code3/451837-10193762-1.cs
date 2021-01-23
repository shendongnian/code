    try
    {
        using(SqlConnection conn = new SqlConnection(connString))
        {
            // Some code for when SqlConnection is succesfully instantiated
        }
    }
    catch (SomeSpecicConnectionInstantiationException ex)
    {
        // Use ex to handle a bizarre instantiation exception?
    }       
