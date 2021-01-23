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
            //if you want to let the code know too put "throw;" here instead.
        }
        finally
        {
            connection.Close();
        }
    }
