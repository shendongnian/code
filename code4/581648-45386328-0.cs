    try
    {
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO tb_mitarbeiter (Vorname) VALUES (@tom)";
        command.Parameters.AddWithValue("@tom", tom);
        connection.Open();
        command.ExecuteNonQuery();
        return "Mitarbeiter wurde angelegt";
    }
    catch (Exception ex)
    {
        return ex.Message;
    }
    finally
    {
       command.Dispose(); command.Close(); 
       connection.Close();
    }
