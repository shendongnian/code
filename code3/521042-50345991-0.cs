      public static DataTable Execute_Query(string connection, string query)
        {
            Logger.Info("Execute Query has been called for connection " + connection);
            connection = "Data Source=" + Connections.run_singlevalue(connection, "server") + ";Initial Catalog=" + Connections.run_singlevalue(connection, "database") + ";User ID=" + Connections.run_singlevalue(connection, "username") + ";Password=" + Connections.run_singlevalue(connection, "password") + ";Connection Timeout=30;";
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.SelectCommand.CommandTimeout = 1800;
                            da.Fill(dt);
                        }
                        con.Close();
                    }
                }
                Logger.Info("Execute Query success");
                return dt;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }   
