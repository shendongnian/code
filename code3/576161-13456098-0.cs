    using (SqlConnection conn = new SqlConnection(connString))
    {
        conn.Open();
        
        List<string[]> values = new List<string[]>();
        using (SqlCommand cmd = new SqlCommand("sp1", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@param1", param1);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        string hash= utils.SHA256.Hashing((string)reader["firstRow"], saltValue);
                        string anotherValue = (string)reader["secondRow"];
                        values.Add(new string[] { hash, anotherValue });
                    }
                    catch (SqlException ex)
                    {
                        //something
                    }
                }
                reader.Close();
            }
        }
    
        if (values.Count > 0)
        {
            using (SqlCommand cmd2 = new SqlCommand("sp2", conn))
            {
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@param1", null);
                cmd2.Parameters.AddWithValue("@param2", null);
                values.ForEach(items =>
                {
                    cmd2.Parameters["@param1"].Value = items[0];
                    cmd2.Parameters["@param2"].Value = items[1];
                    cmd2.ExecuteNonQuery();
                });
            }
        }
        conn.Close();
    }
