    SqlCommand command = new SqlCommand(query, conn);
    DataTable dt = new DataTable();
    using(SqlDataReader reader = command.ExecuteReader())
    {
         dt.Load(reader);
    }
