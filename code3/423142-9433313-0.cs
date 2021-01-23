    var sql = "SELECT * FROM MyTable WHERE MyColumn = @Param1";
    using (var connection = new SqlConnection("..."))
    using (var command = new SqlCommand(sql, connection))
    {
        command.Parameters.AddWithValue("@Param1", param1Value);
        return command.ExecuteReader();
    }
