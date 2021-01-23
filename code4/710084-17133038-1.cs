            connection.Open();
            string sql = "SELECT Nickname FROM Gebruiker WHERE GebruikerID = :gebruikerid";
            command = new OracleCommand(sql, connection);
            command.Parameters.Add(new OracleParameter("gebruikerid", gebruikerid));
            object result = command.ExecuteScalar();
            if(result != null)
                nickname = result.ToString();
