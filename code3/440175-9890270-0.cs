    using (SqlConnection conn = new SqlConnection(...))
    {
        conn.Open();
  
        using (SqlCommand cmd = new SqlCommand("SELECT BlobFieldName FROM Table ...", conn);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                byte[] bytes = reader["BlobFieldName"] as byte[];
                
                using (FileStream stream = new FileStream(...))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                } 
            }
        }
    }
