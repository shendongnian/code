    protected void ProcessData(int x, string data, Socket so)
    {
        if (x < mybuffersize)
        {
            data = data.Trim();
            SendData(so, data);
            string sendData = "Testing send string\0";
            SendData(so, sendData);
        }
    }
