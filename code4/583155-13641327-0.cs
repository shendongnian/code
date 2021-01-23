    static void Main(string[] args)
    {
        Socket s = new Socket(SocketType.Stream, ProtocolType.TCP);
        Socket cl = null;
        System.Net.IPEndPoint endpoint = new System.Net.IPEndPoint(0, 400); // listen on all adapters on port 400
        s.Bind(endpoint);
        
        s.Listen(BACKLOG);
    
        byte[] rcvBuffer = new byte[BUFFSIZE];
    
        for (; ; )
        {
            string text = "";
    
            Console.Clear();
            cl = s.Accept();
            Console.Write("Handling Client >> " + cl.RemoteEndPoint + "\n\n\n");
            cl.Receive(rcvBuffer, BUFFSIZE, SocketFlags.None);
            text = Encoding.ASCII.GetString(rcvBuffer, 0, BUFFSIZE).TrimEnd('\0');
            Console.Write(text);
            cl.Close();
        }
    }
