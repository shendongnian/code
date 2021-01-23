      socket = listeningSocket.Accept();
                        using (NetworkStream nt = new NetworkStream(socket))
                        {
                            using (StreamReader reader = new  StreamReader(nt))
                            {
                                string line;
                                string line;
                            
                            //  while ((line = reader.ReadLine()) != null)//as networkstream never got eof. was using it as replacement while(true)                            // {
                              while (true)
                              {
                                try
                                {
                                    line = reader.ReadLine();
                                }
                                catch (IOException)
                                {
                                    break;
                                }
                                Console.WriteLine(line);
                               }
                            }//using reader
                        }//using ns
