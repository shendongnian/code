    public void sendMsg(string s)
    {
        bool x = true;
        while (true)
        {
            Thread.Sleep(500);
            if (x == true)
            {
                byte[] msgBuffer = Encoding.ASCII.GetBytes(s);
                sck.Send(msgBuffer);
                x = false;
            }
        }
    }
