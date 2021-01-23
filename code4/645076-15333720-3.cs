    private static void Main(string[] args)
    {
    try
    {
        using (TcpClient client = new TcpClient(ip, port))
        {
            using (NetworkStream networkStream = client.GetStream())
            {
                using (StreamWriter writer = new StreamWriter(networkStream))
                {
                    writer.WriteLine("# hello, tcp world #");
                    writer.Flush();
                }
                networkStream.Flush();
                networkStream.Close();
            }
            client.Close();
            //Thread.Sleep(10);
         }
         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.Message);
         }
    }
