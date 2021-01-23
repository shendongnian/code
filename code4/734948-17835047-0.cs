     SqlConnection lSqlConnection = new SqlConnection("Data Source=SEBA-PC\\sqlexpress;Initial Catalog=Batalla_Naval;Integrated Security=True");
                    SqlCommand lSqlCommand = null;
                    try
                    {
                        lSqlCommand = new SqlCommand();
                        lSqlCommand.CommandText = SqlQuery;
                        lSqlCommand.CommandType = CommandType.Text;
                        var result = lSqlCommand.ExecuteScalar();
                        int MyID = Convert.ToInt32(result);
                        
                    }
                    catch(ex)
                    {
                        // DO SOMETHING
                    }
