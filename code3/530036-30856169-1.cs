    async Task<TcpClient> AcceptAsync(TcpListener listener, CancellationToken ct)
    {
        using (ct.Register(listener.Stop))
        {
            try
            {
                return await listener.AcceptTcpClientAsync();
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.Interrupted)
                    throw new OperationCanceledExeption();
                throw;
            }
        }
    }
