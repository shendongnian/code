    byte[] picbyte = System.IO.File.ReadAllBytes(imgFile);
    using (var connection = new OleDbConnection(connstring))
    using (var command = connection.CreateCommand())
    {
        connection.Open();
        command.CommandText = "INSERT INTO [Image] (Img) VALUES (@Img)";
        command.Parameters.AddWithValue("@Img", picbyte);
        command.ExecuteNonQuery();
    }
