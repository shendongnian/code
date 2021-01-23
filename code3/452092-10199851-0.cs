            IPAddress ip = IPAddress.Parse("192.168.0.1");
            Ping ping = new Ping();
            for (int i = 0; i < 4; ++i)
            {
                var reply = ping.Send(ip);
                Console.WriteLine("Reply from {0} Status: {1} time:{2}ms", 
                                  reply.Address, 
                                  reply.Status, 
                                  reply.RoundtripTime);
            }
