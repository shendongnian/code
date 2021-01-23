           using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    //select just schema of the table.
                    command.CommandText = "select * from members where 1=2;";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                foreach (Member item in memebers)
                                {
                                    DataRow row = dt.NewRow();
                                    
                                    row.SetField<string>("", item.FirstName);
                                    row.SetField<string>("", item.LastName);
                                    row.SetField<int>("", item.Age);
                                    //
                                    // number of SetField should be equal to number of selected columns.
                                    //
                                    dt.Rows.Add(row);
                                }
                                adapter.Update(dt);
                            }                         
                        }   
                    }
                }
            }
