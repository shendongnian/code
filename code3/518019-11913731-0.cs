        public bool removeStock(string user_name, string stock_symbol)
        {
            using(SqlConnection connection = new SqlConnection("YOUR_CONNECTION_STRING"))
            {
                using(SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM user_stocks WHERE user_name=@USERNAME AND stock_symbol=@STOCKSYMBOL";
                        command.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = user_name.Trim();
                        command.Parameters.Add("@STOCKSYMBOL", SqlDbType.VarChar).Value = stock_symbol.Trim();
                        connection.Open();
                        int i = command.ExecuteNonQuery();
                        if (i > 0)
                            return false;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        connection.Close();
                        return false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        } 
