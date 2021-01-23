    using(var con= new SqlConnection(connectionString))
    using(var insertCommand = new SqlCommand("INSERT INTO dbo.Table VALUES(@Colname)", con))
    {
        con.Open();
        foreach(DataRow row in table.Rows)
        {
            insertCommand.Parameters.Clear();
            insertCommand.Parameters.AddWithValue("Colname", row.Field<string>("Colname"));
            insertCommand.ExecuteNonQuery();
        }
    }
