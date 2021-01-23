    public static void TcpHandler(Object o)
    {
        lock(lockObject)
        {
            // active is already declared
            while(_active)
            {
                var tcpClient = (TcpClient) o;
    
                // .. do some send and receive...
        
                Console.WriteLine("Something here..");
    
                Thread.Sleep(_interval * _maxConnections);
            }
        }
    }
