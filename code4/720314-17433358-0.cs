    string sql = "SELECT * FROM Foo WHERE SomeDate = @SomeDate";
    using (var conn = new SqlConnection(...))
    {
        conn.Open();
        using (var command = new SqlCommand(sql, conn))
        {
            command.Parameters.Add("@SomeDate", SqlDbType.Date).Value = DateTime.Today;
            using (var reader = command.ExecuteReader())
            {
                // read the data here...
            }
        }
    }
