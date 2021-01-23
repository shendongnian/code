    string ConnectionString = "server=myserver;uid=sa;pwd=secret;database=mydatabase";
    using (var con = new SqlConnection(ConnectionString)) {
        string CommandText = "SELECT p.firstname, p.lastname, o.operderdate " +
                             "FROM persons p LEFT JOIN orders o ON p.person_id = o.person_id";
        using (var cmd = new SqlCommand(CommandText, con)) {
            con.Open();
            using (var reader = cmd.ExecuteReader()) {
                while (reader.Read()) {
                    Console.WriteLine("{0} {1}, {2}", reader["firstname"], reader["lastname"], reader["operderdate"]);
                }
            }
        }
    }
