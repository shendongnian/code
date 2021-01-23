    try
    {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO tb_mitarbeiter (Vorname) VALUES ('tom')";
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
           connection.Close();
     }
