            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Trying to connect");
            socket.Blocking = false;
            try
            {
                socket.Connect("8.8.8.8", 5050);
            }
            catch (Exception ex)
            {
                if (ex is SocketException) && ((SocketException)ex).ErrorCode == 10035) // There is a socket problem and this problem is because of being in non-blocking mode? Then this is just a warning
                {
                    // Waiting for connection
                    int time = 0;
                    while (time < 1000) // If it was lower than 1 Sec
                    {
                        // Do what you want
                        if (socket.Connected) // If connected then break
                            break;
                        System.Threading.Thread.Sleep(10); // Wait 10milisec
                        time += 10;
                    }
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            if (!socket.Connected)
                Console.WriteLine("Aborted");
            else
                Console.WriteLine("Connected");
