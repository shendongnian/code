    while (!this._Stream.IsConnected)
    {
        try
        {
            ((NamedPipeClientStream)this._Stream).Connect(1000);
        }
        catch
        {
        }
    }
