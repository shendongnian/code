    using (SqlConnection connection = new SqlConnection(Connection.ConnectionString) )
    {
        using(SqlCommand command = new SqlCommand("insert into  OldCustomers select * from customers",connection))
        {
            connection.Open();
            var numRows = command.ExecuteNonQuery();
            Console.WriteLine("Affected Rows: {0}",numRows);
        }
    }
