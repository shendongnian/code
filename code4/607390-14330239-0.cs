    // The SqlConnection, SqlCommand and SqlDataReader need to be in using blocks
    // so that they are disposed in a timely manner. This does not clean  up
    // memory, it cleans up unmanaged resources like handles
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM OldTable", conn))
        {
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       media m = new media
                       {
                           // Don't convert - cast instead. These are already the correct
                           // type.
                           docid = (int) dr["Id"],
                           // There are more efficient ways to do this, but
                           // Convert.ToByte was copying only a single byte
                           Content = dr["BlobData"],
                           madiaName = (string)dr["Name"]
                       }
                      
                        // You probably want to insert _all_ of the rows.
                        // Your code was only inserting the last
                        InsertInNewDb(m);
                    }
                }
            }
        }
    }
