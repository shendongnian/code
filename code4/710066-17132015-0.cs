     public string GetEigenaarBlog(int gebruikerid)
                {
              string nickname = null;
                    try
                    {
                        connection.Open();
                        string sql = "SELECT NICKNAME FROM GEBRUIKER WHERE GEBRUIKERID = :GEBRUIKERID";
                        command = new OracleCommand(sql, connection);
                        command.Parameters.Add(new OracleParameter(":GEBRUIKERID", gebruikerid));
                        nickname = Convert.ToString(command.ExecuteReader());           
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();                   
                    }
         return nickname;
    
                }
