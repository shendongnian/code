                try
                {
                    using(var client = new SshClient("ssh server id", "sshuser", "sshpassword")) // establishing ssh connection to server where MySql is hosted
                    {
                        client.Connect();
                        if (client.IsConnected)
                        {
                            var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                            client.AddForwardedPort(portForwarded);
                            portForwarded.Start();
                            using (MySqlConnection con = new MySqlConnection("SERVER=127.0.0.1;PORT=3306;UID=someuser;PASSWORD=somepassword;DATABASE=DbName"))
                            {
                                using (MySqlCommand com = new MySqlCommand("SELECT * FROM tableName", con))
                                {
                                    com.CommandType = CommandType.Text;
                                    DataSet ds = new DataSet();
                                    MySqlDataAdapter da = new MySqlDataAdapter(com);
                                    da.Fill(ds);
                                    foreach (DataRow drow in ds.Tables[0].Rows)
                                    {
                                        Console.WriteLine("From MySql: " + drow[1].ToString());
                                    }
                                }
                            }
                            client.Disconnect();
                        }
                        else
                        {
                            Console.WriteLine("Client cannot be reached...");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
