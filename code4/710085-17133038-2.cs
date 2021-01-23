    public string GetEigenaarBlog(int gebruikerid)
    {
        string nickname = null;
        try
        {
            connection.Open();
            string sql = "SELECT Nickname FROM Gebruiker WHERE GebruikerID = :gebruikerid";
            command = new OracleCommand(sql, connection);
            command.Parameters.Add(new OracleParameter("gebruikerid", gebruikerid));
            OracleDataReader reader = command.ExecuteReader();
            // Now try to read from the reader (and position the reader on the first record returned)
            if(reader.Read())
                nickname = reader[0].ToString();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return nickname;
