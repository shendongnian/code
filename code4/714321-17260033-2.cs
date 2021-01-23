      socket = listeningSocket.Accept();
                        using (NetworkStream nt = new NetworkStream(socket))
                        {
                            using (StreamReader reader = new  StreamReader(nt))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    Console.WriteLine(line);
                                }
                            }
                        }
