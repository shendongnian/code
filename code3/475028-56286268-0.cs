    After so much of research the below code worked for me
    Hope it may help you also
    public static string GetRDSConnectionString()
            {
                string Database = "<yourdb>";
                string value = "";      
                string mysqlport = "3306";           
                uint sqlport = Convert.ToUInt32(mysqlport);
                string mysqlhostname = "<aws-hostname.com>";
                string ssh_host = "100.1.1.1";
                int ssh_port = 22;
                string ssh_user = "ubuntu";
                var keyFile = new PrivateKeyFile(@"C:\Automation\LCI\harvest-dev-kp.pem");
                var keyFiles = new[] { keyFile };
                var uname = "ubuntu";
                MySqlConnection con = null;
                MySqlDataReader reader = null;
                var methods = new List<AuthenticationMethod>();
                methods.Add(new PasswordAuthenticationMethod(uname, ""));
                methods.Add(new PrivateKeyAuthenticationMethod(uname, keyFiles));
                ConnectionInfo conInfo = new ConnectionInfo(ssh_host, ssh_port, ssh_user, methods.ToArray());
                conInfo.Timeout = TimeSpan.FromSeconds(1000);
                using (var client = new SshClient(conInfo))
                {
                    try
                    {
                        client.Connect();
                        if (client.IsConnected)
                        {
                            Console.WriteLine("SSH connection is active");
                        }
                        else
                        {
                            Console.WriteLine("SSH connection is inactive");
                        }
                        string Localport = "3306";
                        string hostport = "3306";
                        var portFwdL = new ForwardedPortLocal("127.0.0.1", Convert.ToUInt32(hostport), mysqlhostname, Convert.ToUInt32(Localport));
                        client.AddForwardedPort(portFwdL);
                        portFwdL.Start();
                        if (portFwdL.IsStarted)
                        {
                            Console.WriteLine("port forwarding is started");
                        }
                        else
                        {
                            Console.WriteLine("port forwarding failed");
                        }                    
                        string connectionstring = "Data Source=localhost;Initial Catalog=<DBNAME>I;User ID=<USERNAME>;Password=<PASSWORD>;SslMode=none";
                      
                        con = new MySqlConnection(connectionstring);
                        MySqlCommand command = con.CreateCommand();
                        command.CommandText = "<YOUR QUERY>";
                        try
                        {
                            con.Open();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            value = reader["<db_col_name>"].ToString();
    
                        }
                        client.Disconnect();
                    }
                    catch (SocketException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        
                        Console.WriteLine("SSh Disconnect");
                    }
    
                }
    
                //Console.ReadKey();
                return value;
            }
        }
