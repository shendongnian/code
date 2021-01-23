    byte[] header;
    byte[] buffer;
    int bytesRead;
    public void ReadHeader()
    {
        bytesNeeded = 4;
        bytesRead = 0;
        BeginReadHeader();
    }
    public void BeginReadHeader()
    {
        BeginReceive(header, bytesRead, bytesNeeded-bytesRead, EndReadHeader);
    }
    public void EndReadHeader()
    {
        int read = EndReceive();
        
        if(read == 0)
        {
            CloseSocket();
            return;
        }
        bytesRead += read;
        if(bytesRead == byteNeeded)
            ReadData();
        else
            BeginReadHeader();
    }
    public void ReadData()
    {
        bytesNeeded = BitConverter.ToInt32(header, 0);
        bytesRead = 0;
        if(buffer.Length < bytesNeeded)
            buffer = new byte[bytesNeeded];
        BeginReadData();
    }
    public void BeginReadData()
    {
        BeginReceive(buffer, bytesRead, bytesNeeded-bytesRead, EndReadData);
    }
    public void EndReadData()
    {
        int read = EndReceive();
        
        if(read == 0)
        {
            CloseSocket();
        }
        bytesRead += read;
        if(bytesRead == byteNeeded)
        {
            HandleData();
        }
        else
            BeginReadData();
    }
    public void HandleData()
    {
         // handle data in buffer. BinaryReader
         ReadHeader();
    }
