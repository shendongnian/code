            using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=TestDB;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Test";
                    SqlParameter text = new SqlParameter("@Text", SqlDbType.NVarChar, 1000);
                    text.Direction = ParameterDirection.Output;
                    command.Parameters.Add(text);
                    using (DataTable dt = new DataTable())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(dt);
                        }
                    }
                    Trace.WriteLine(text.Value);
                    connection.Close();
                }
            }
