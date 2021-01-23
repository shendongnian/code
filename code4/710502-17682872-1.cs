        connection.Open();
        byte[] bytes = (byte[])cmd.ExecuteScalar();
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (MemoryStream memoryStream = new MemoryStream(bytes))
        {
            memoryStream.Position = 0;
            ReceiptCollection items = (ReceiptCollection)binaryFormatter.Deserialize(memoryStream);
        }
