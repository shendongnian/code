    using (var context = new Context(1))
                    {
                        using (Socket client = context.Socket(SocketType.REQ))
                        {
                            client.Connect("tcp://127.0.0.1:12345");
                            int i = 0;
                            while (true)
                            {
                                string request = i.ToString() + "_Hello_ ";
                                i++;
                                Console.WriteLine("Sending request..." + i.ToString());
                                client.Send(request, Encoding.Unicode); 
    
                                string reply = client.Recv(Encoding.Unicode).ToString();
    
                                Console.WriteLine("Received reply :" + reply);
                            }
                        }
                    }
