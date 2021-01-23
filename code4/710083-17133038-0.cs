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
