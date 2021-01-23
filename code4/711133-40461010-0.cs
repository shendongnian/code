    public DataTable Execute(string cmd)
    {
            bool networkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (networkUp)
            {
                try
                {
                        SqlConnection connection = new SqlConnection("ConnectionString");
                        SqlCommand command = new SqlCommand(cmd);
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            sda.SelectCommand = command;
                            command.Connection = connection;
                            connection.Open();
                            sda.Fill(dt);
                            connection.Close();
                            if (dt != null && dt.Columns.Count > 0)
                                return dt;
                            else
                                return null;
                        }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Network is disconnect");
                return null;
            }
        return null;
    }  
    
