    string sql = "SELECT * FROM tblPerson WHERE LastName LIKE @pattern";
    cmd = new SqlCommand(sql);
    cmd.Connection = "server=test;uid=sa;pwd=manager;database=northwind";
    cmd.Parameters.AddWithValue("@pattern", "A%"); // Names beginning with "A"
    using (SqlDataReader reader = cmd.ExecuteReader()) {
        // Get column indexes
        int idOrdinal = reader.GetOrdinal("ID");
        int firstNameOrdinal = reader.GetOrdinal("FirstName");
        int lastNameOrdinal = reader.GetOrdinal("LastName");
        while(reader.Read()) {
            var p = new Person();
            p.ID = reader.GetInt32(idOrdinal);
            p.FirstName = reader.GetString(firstNameOrdinal);
            p.LastName = reader.GetString(lastNameOrdinal);
            people.Add(p);
        }
    }
