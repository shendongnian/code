    using(SqlConnection conn = Class3.GetConnection())
    using(SqlCommand cmd = new SqlCommand("whatever", conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        using(SqlDataReader rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
               // do something
            }
        }
    }
