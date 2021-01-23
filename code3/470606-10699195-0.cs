    Int32 colnumber = 0;
    string sql = "SELECT count(*) FROM sys.columns";
    using (SqlConnection conn = new SqlConnection(connString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            colnumber = (Int32)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
