    using (var con = new SqlConnection(connectionString))
    using (var cmd = new SqlCommand("StoredProcedureName", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Gender", typeof(string));
        cmd.Parameters.Add("@Name", typeof(string));
        con.Open();
        foreach (var person in persons)
        {
            cmd.Parameters["@Gender"].Value = person.IsFemale ? "female" : "male";
            cmd.Parameters["@Name"].Value = person.Name;
            cmd.ExecuteNonQuery();
        }
    }
