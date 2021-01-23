    TcpClient newClient = (TcpClient)client;
    
    NetworkStream ns = newClient.GetStream()
    
    byte[] bytes = new byte[1024];
    
    bytes = Encoding.ASCII.GetBytes("X");
    
    Console.WriteLine("X");
    
    ns.Write(bytes, 0, bytes.Length);
