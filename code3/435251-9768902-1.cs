        static void Main(string[] args)
        {
            try
            {
                using (TcpClient clientSock = new TcpClient(IPAddress.Loopback.ToString(), 3000))
                {
                    using (Stream clientStream = clientSock.GetStream())
                    {
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        byte[] helloMessage = encoder.GetBytes("Hello Server !");
                        clientStream.Write(helloMessage, 0, helloMessage.Length);
                        clientStream.Flush();
                        using (StreamReader streamReader = new StreamReader(clientStream))
                        {
                            while(true)
                            {
                                char[] buffer = new char[1024];
                                streamReader.Read(buffer,0, 1024);
                                Console.Out.WriteLine(new string(buffer));
                            }
                        }
                    }
                }
                
                Console.ReadLine();
            }
            catch (Exception)
            {
                // do something here
                
                throw;
            }
        }
