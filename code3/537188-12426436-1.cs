    List<String> list = new List<String>() { "A", "B", "C" };
    using (var con = new SqlConnection(connectionString))
    {
        con.Open();
        using (var cmd = new SqlCommand("INSERT INTO TABLE(Column)VALUES(@Column)", con))
        {
            cmd.Parameters.Add("@Column", SqlDbType.VarChar);
            foreach (var value in list)
            {
                cmd.Parameters["@Column"].Value = value;
                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }
    }
