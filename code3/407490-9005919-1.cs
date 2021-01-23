    while (!reader.IsClosed && reader.Read())
    {
        n++;
        if (n > 5000) // Once here close reader
        {
            if (reader != null)
            {
                 ((NpgsqlDataReader)reader).Close(); //Closed
            }
        }
     }
