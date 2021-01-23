    namespace ServerSideApplication
    {
        class Program
        {
         static void Main(string[] args)
          {
            TcpListener socketListener = new TcpListener(8888);
            TcpClient netClient = default(TcpClient);
            StreamReader sr;
            StringBuilder sb = new StringBuilder();
            socketListener.Start();
            sr = new StreamReader("c:\\test.txt");
            sb.Append(sr.ReadToEnd());
            while (true)
            {
                netClient = socketListener.AcceptTcpClient();
                Console.WriteLine("Accepted Connection From Client" + Environment.NewLine + "Client connected");
                ServerSide ss = new ServerSide();
                ss.startServerSide(netClient, sb);
            }
            socketListener.Stop();
        }
    }
    class ServerSide
    {
        TcpClient netClient;
        StringBuilder sb;
        public void startServerSide(TcpClient netClient, StringBuilder sb)
        {
            this.netClient = netClient;
            this.sb = sb;
            Thread thread = new Thread(processRequest);
            thread.Start();
        }
        private void processRequest()
        {
            byte[] data = new byte[4096];
            int bytesRead;
            NetworkStream strm = netClient.GetStream();
            bytesRead = 0;
                try
                {
                    
                    NetworkStream ns = netClient.GetStream();
                    string clientChar = "", s = "";
                    do
                    {
                        bytesRead = ns.Read(data, 0, (int)data.Length);
                        clientChar = Encoding.ASCII.GetString(data).Replace("\0", "");
                        s += clientChar;
                    } while (clientChar != Environment.NewLine);
                    s = s.Trim();
                    ASCIIEncoding encoder = new ASCIIEncoding();
                    if (String.IsNullOrEmpty(s))
                    {
                        data = encoder.GetBytes("There is no data in the file.");
                        Console.WriteLine("There is no data in the file.");
                    }
                    
                    if (sb.ToString().Contains(s))
                    {
                        data = encoder.GetBytes("It Is Present In The File.");
                    }
                    else
                    {
                        data = encoder.GetBytes("It Is Not Present In The File.");
                    }
                    strm.Write(data, 0, data.Length);
                    strm.Flush();
                    Console.WriteLine("Closing client");
                    netClient.Close();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
        }
    }
}
