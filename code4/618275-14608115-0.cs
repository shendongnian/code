    void callback(IAsyncResult ar)
    {
        try
        {
            serverSock.EndReceive(ar);
            byte[] receiveBuffer = new byte[8192];
            int rec = serverSock.Receive(receiveBuffer, receiveBuffer.Length, 0);
            //add these lines
            if (rec == 0)
            {
                Disconnected(this);
                return;
            }
            if (rec < receiveBuffer.Length)
            {
                Array.Resize<byte>(ref receiveBuffer, rec);
            }
            if (Receieved != null)
            {
                Receieved(this, receiveBuffer);
            }
            serverSock.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            Close();
            if (Disconnected != null)
            {
                Disconnected(this);
            }
        }
    }
