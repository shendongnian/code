    public void Disconnect()
    {
        if (IsConnectionOpen)
        {
            _continue = false;
            readThread.Join();
            sp.Close();
        }
    }
