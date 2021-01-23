            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                Task.Factory.StartNew(() =>
                    {
                        Thread.Sleep(1000);
                        socket.Close();
                    });
                try
                {
                    socket.Connect("192.168.2.123", 1234);
                }
                catch (SocketException sex)
                {
                    if (sex.ErrorCode == 10038)
                        Console.WriteLine("Timeout");
                    else
                        throw;
                }
            }
