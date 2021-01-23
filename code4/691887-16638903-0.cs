    string insertStmt = "INSERT INTO tbl (id) " + 
                        " OUTPUT Inserted.Id " + 
                        " SELECT COUNT(*) + 1 AS id from tbl";
    using (SqlConnection conn = new SqlConnection(-your-connection-string-here-))
    using (SqlCommand cmd = new SqlCommand(insertStmt, conn))
    {
        conn.Open();
        // execute your INSERT statement into a SqlDataReader
        using(SqlDataReader reader = cmd.ExecuteReader())
        {
            // read the values returned from the OUTPUT clause
            while(reader.Read())
            {
                int insertedID = reader.GetInt32(0);
                // do something with those values....                
            }
        }
        conn.Close();
    }
