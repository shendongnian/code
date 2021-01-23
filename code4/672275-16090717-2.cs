      Parallel.ForEach(sql, s=>
                //foreach (Sql s in sql)
                {
                    foreach (string q in s.queries)
                    {
                        using (connection = new SqlConnection(s.connection))
                        {
                            connection.Open();
                            DataTable dt = new DataTable();
                            dt.TableName = s.name;
                            command = new SqlCommand(q, connection);
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = command;
                            adapter.Fill(dt);
                            //adapter.Dispose();
    
                            lock(data){
                                data.Add(dt);
                            }
                        }
                    }
                }
