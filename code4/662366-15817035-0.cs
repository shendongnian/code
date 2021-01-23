    public Task<bool> Connect()
    {
        // Eager validation of state...
        lock (_connectingLock)
        {
            if (_connecting)
                throw new IOException("Already connecting");
            _connecting = true;
        }
        return ConnectImpl();
    }
    private async Task<bool> ConnectImpl()
    {
        try {
             await tcpClient.ConnectAsync(...); 
        }           
        catch (SocketException e)
        {
            return false;
        }
        finally
        {
            lock (_connectingLock)
            {
                _connecting = false;
            }
        }
    }
