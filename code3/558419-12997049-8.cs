    cmd.Connection.Open();
    try
    {
        SqlDataReader r = cmd.ExecuteReader();
    }
    finally
    {
        cmd.Connection.Close();
    }
