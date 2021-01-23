    async Task<TcpClient> AcceptAsync(TcpListener listener, CancellationToken ct)
    {
        using (ct.Register(listener.Stop))
        {
            try
            {
                return await listener.AcceptTcpClientAsync();
            }
            catch (SocketException e) when (e.SocketErrorCode == SocketError.Interrupted)
            {
                throw new OperationCanceledException();
            }
            catch (ObjectDisposedException) when (ct.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }
        }
    }
