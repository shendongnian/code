    try
    {
        using(SqlConnection conn = new SqlConnection(connString))
        {
            // Some code for then it works
        }
    }
    catch (SomeSpecicConnectionInstantiationException ex)
    {
        // Use ex to inform the user perhaps?
    }       
