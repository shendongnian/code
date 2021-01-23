      public void ExecuteNonQuery(string cmd)
            {
                bool networkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                if (networkUp)
                {
                    try
                    {
                      SqlConnection connection = new SqlConnection("ConnectionString");
                      SqlCommand command = new SqlCommand(cmd);
                      command.Connection = connection;
                      connection.Open();
                      command.ExecuteNonQuery();
                      connection.Close();
                    }
                    catch (Exception ex)
                    {
                       Console.WriteLine(ex.Message);
                    }
                }
            }
