        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, items);
        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, connection))
        {
            byte[] bytes = new byte[memoryStream.Capacity];
            bytes = memoryStream.GetBuffer();
            connection.Open();
            cmd.Parameters.AddWithValue("@MasterObject", bytes);
            cmd.ExecuteNonQuery();
        }
