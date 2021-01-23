    private void BeginReceiveFromWebserver(ClientSocket clientSocket)
        {
            try
            {
                clientSocket.CommunicationSocket.BeginReceive(clientSocket.Buffer, 0, clientSocket.Buffer.Length,
                                                             SocketFlags.None, new AsyncCallback(ReceiveFromWebserverCallback), clientSocket);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\nfrom Source: " + e.Source + "\nand Stack Trace: " + e.StackTrace);
                //XXX TODO
            }
        }
        private void ReceiveFromWebserverCallback(IAsyncResult ar)
        {            
            ClientSocket clientSocket = ar.AsyncState as ClientSocket;
            try
            {
                int bytesRead = clientSocket.CommunicationSocket.EndReceive(ar);
                if (bytesRead > 0)
                {
                    if(!clientSocket.AllBytesReceived)
                    {
                        // No locks needed here, because it works like a loop
                        clientSocket.TotalBytesReceived+=bytesRead;
                        clientSocket.BufferUsed++;
                        clientSocket.AddBuffer();
                        clientSocket.SendingToBrowserCompleted.WaitOne();
                        BeginSend(clientSocket, bytesRead);
                        clientSocket.CommunicationSocket.BeginReceive(clientSocket.Buffer, 0, clientSocket.Buffer.Length,
                                                            SocketFlags.None, new AsyncCallback(ReceiveFromWebserverCallback), clientSocket);
                    }
                    else
                    {
                        // all bytes Received
                    }
                }
                else
                {
                    Console.WriteLine("Webserver Closed Connection");
                    //XXX TODO, Webserver closed the Connection
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\nfrom Source: " + e.Source + "\nand Stack Trace: " + e.StackTrace);
                //XXX TODO
            }
        }
