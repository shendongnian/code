    public static void TcpHandler(Object o)
    {
        // active is already declared
        while(_active)
        {
            //DO NON-SOCKET RELATED STUFF HERE
            // ... code ...
            //
            //DO SOCKET RELATED STUFF HERE
            lock(lockObject)
            {
                var tcpClient = (TcpClient) o;
    
                // .. do some send and receive...
        
                Console.WriteLine("Something here..");
    
                Thread.Sleep(_interval * _maxConnections);
            }
        }
    }
