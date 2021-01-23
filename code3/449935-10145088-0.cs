    void SaveImage(byte[] image)
    {
        using (var conn = new MySqlConnection(ConnectionString))
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "INSERT INTO pictures (Product, Manufacturer, Description, Price, Image) VALUES ('New_Product', 'New_Manufacturer', 'New_Description', '0', ?Image)";
            cmd.Parameters.Add("?Image", image);
            cmd.ExecuteNonQuery();    
        }
    }
    byte[] GetImage(string product)
    {
        using (var conn = new MySqlConnection(ConnectionString))
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "SELECT Image FROM pictures WHERE Product = ?product";
            cmd.Parameters.Add("?product", product);
            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return null;
                }
                const int CHUNK_SIZE = 2 * 1024;
                byte[] buffer = new byte[CHUNK_SIZE];
                long bytesRead;
                long fieldOffset = 0;
                using (var stream = new MemoryStream())
                {
                    while ((bytesRead = reader.GetBytes(reader.GetOrdinal("Image"), fieldOffset, buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, (int)bytesRead);
                        fieldOffset += bytesRead;
                    }
                    return stream.ToArray();
                }
            }
        }
    }
