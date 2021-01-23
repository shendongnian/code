    // I'm assuming you're opening the connection already
    string sql = "INSERT INTO ShowDB(ITEM) VALUES (@Name)";
    using (var command = new SqlCommand(sql, connection))
    {
        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = "John's shoes";
        command.ExecuteNonQuery();
    }
