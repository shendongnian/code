    public string GetEigenaarBlog(int gebruikerid)
    {
        try
        {
            connection.Open();
            string sql = "SELECT NICKNAME FROM GEBRUIKER WHERE GEBRUIKERID = :GEBRUIKERID";
            command = new OracleCommand(sql, connection);
            command.Parameters.Add(new OracleParameter(":GEBRUIKERID", gebruikerid));
            string nickname = Convert.ToString(command.ExecuteReader());
            return nickname;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return null;
        }
        finally
        {
            connection.Close();
        }
    }
