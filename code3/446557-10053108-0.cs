    using (SqlConnection conn = new SqlConnection(connString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            newProdID = (Int32)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            //Do stuff
        }
    }
