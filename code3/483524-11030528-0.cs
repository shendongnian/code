    try
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", test); // assign value to parameter 
                cmd.ExecuteNonQuery();
            }
        }
    }
    catch (SqlException ex)
    {
        string msg = "Insert Error:";
        msg += ex.Message;
    }
