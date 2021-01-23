    try
    {
        connection.Open();
        SqlCommand cmd = new SqlCommand("sp_ChangeState", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
    }
    finally
    {
        connection.Close();
    }
    base.OnStop();
