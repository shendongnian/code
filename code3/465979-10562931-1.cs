    Int32 _ID = 0;
    //you could use second variant sql= "SELECT MAX(SomeID) FROM SomeTable";
    string sql =
        "SELECT @@IDENTITY AS 'Identity'";
    using (SqlConnection conn = new SqlConnection(connString))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        try
        {
            conn.Open();
            _ID = (Int32)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
