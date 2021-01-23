                            TcpClient tcpClient = new TcpClient();
                            try
                            {
                                    tcpClient.Connect("127.0.0.1", 9081);
                                    Console.WriteLine("Port " + 9081+ " Open");
                            }
                            catch (Exception){
                            
                                    Console.WriteLine("Port " + 9081+ " Closed");
                            }
