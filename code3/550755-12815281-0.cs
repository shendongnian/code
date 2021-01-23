    void ExchangePackets(IPEndPoint ipe1, IPEndPoint ipe2)
    {
        TcpClient tcp1 = new TcpClient();
        tcp1.Connect(ipe1);
        TcpClient tcp2 = new TcpClient();
        tcp2.Connect(ipe2);
        Task.Factory.StartNew(() => ByPass(tcp1, tcp2), TaskCreationOptions.LongRunning);
        Task.Factory.StartNew(() => ByPass(tcp2, tcp1), TaskCreationOptions.LongRunning);
    }
    void ByPass(TcpClient tcp1, TcpClient tcp2)
    {
        using (tcp1)
        using (tcp2)
        {
            Stream s1 = tcp1.GetStream();
            Stream s2 = tcp2.GetStream();
            byte[] buf = new byte[0x10000];
            int len = s1.Read(buf, 0, buf.Length);
            while (len > 0)
            {
                s2.Write(buf, 0, len);
                len = s1.Read(buf, 0, buf.Length);
            }
        }
    }
