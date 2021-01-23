    public void sendMsg(string s)
    {
        while (true)
        {
            Thread.Sleep(500);
            byte[] msgBuffer = Encoding.ASCII.GetBytes(s);
            sck.Send(msgBuffer);
        }
    }
