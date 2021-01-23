    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
    {
        using (var cmd = new SqlCommand(queryString, connection))
        {
            connection.Open();
            cmd.CommandType = ??.StoredProcedure; // Can't remember what enum name is prob SqlCommandType or something
            cmd.Parameters.AddWithValue("date_from", DateTime.blah.blah);
            cmd.Parameters.AddWithValue("date_to", DateTime.blah.blah);
            var reader = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            return dt.DefaultView;
        }
    }
