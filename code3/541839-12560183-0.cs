    public byte[] GetImage(string id)
    {
        using (var conn = new SqlConnection("YOUR CONNECTION STRING COMES HERE"))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            // TODO: replace the imageData and id columns and tableName with your actual
            // database table names
            cmd.CommandText = "SELECT imageData FROM tableName WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    // there was no corresponding record found in the database
                    return null;
                }
    
                const int CHUNK_SIZE = 2 * 1024;
                byte[] buffer = new byte[CHUNK_SIZE];
                long bytesRead;
                long fieldOffset = 0;
                using (var stream = new MemoryStream())
                {
                    while ((bytesRead = reader.GetBytes(reader.GetOrdinal("imageData"), fieldOffset, buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, (int)bytesRead);
                        fieldOffset += bytesRead;
                    }
                    return stream.ToArray();
                }            
            }
        }
    }
