        using(MySqlConnection cn2 = GetConnection("second_connection_string");
        {
            cn2.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO T2 (a,b) values(@a,@b)", cn2);
            cmd.Parameters.AddWithValue("@a", string.Empty); // Suppose the "a" field is a string
            cmd.Parameters.AddWithValue("@b", string.Empty); // Suppose the "b" field is a string
            foreach(DataRow r in dtSource)
            {
                cmd.Parameters["@a"].Value = r["a"].ToString();
                cmd.Parameters["@b"].Value = r["b"].ToString();
                cmd.ExecuteNonQuery();
            }
        }
