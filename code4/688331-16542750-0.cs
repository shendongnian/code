    try
    { 
        var command = new SqlCommand("...");
        command.CommandTimeout = 5; // 5 seconds
        command.ExecuteNonQuery();
    }
    catch(SqlException ex)
    {
        // handle the exception...
    }
