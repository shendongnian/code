                        string toRead = "";
                        do
                        {
                            if (reader.Peek() == -1)
                            {
                                Thread td = new Thread(TryReading);
                                td.Start();
                                Thread.Sleep(400);
                                if (ReadSuccess == false)
                                {
                                    try
                                    {
                                        td.Abort();
                                    }
                                    catch (Exception ex) { }
                                    break;
                                }
                                else
                                {
                                    toRead += ReadChar;
                                    ReadSuccess = false;
                                } 
                            }
                            toRead += (char)reader.Read();
                        } while (true);
