    // for illustration ONLY
    TaskCompletionSource<int> source = new TaskCompletionSource<int>();
    sock.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ar =>
    {
        try
        {
            int val = ((Socket)ar.AsyncState).EndReceive(ar);
            source.SetResult(val);
        }
        catch (Exception ex)
        {
            source.SetException(ex);
        }
    }, sock);
    return source.Task;
