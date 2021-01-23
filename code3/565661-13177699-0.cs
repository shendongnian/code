    public DataSet ExecuteDataSet(string text, SqlParameter[] paramList)
            {
                using (SqlCommand sqlCommand = new SqlCommand(text, sqlConnection))
                {
                    if (paramList != null)
                    {
                        foreach (var param in paramList)
                        {
                            sqlCommand.Parameters.Add(param);
                        }
                    }
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    DataSet dataSet=new DataSet();
                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }
            }
