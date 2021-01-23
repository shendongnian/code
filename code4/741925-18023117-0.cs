    internal void Connect(Action<bool> onConnected)
    {
        Func<AsyncCallback, object, IAsyncResult> beginConnect =
            (callback, s) => 
                {
                    var asyncResult = _socket.BeginConnect(Endpoint, callback, s);
                    var success = asyncResult.AsyncWaitHandle.WaitOne(20, true);
                    if(!success)
                    {
                        onConnected(false);
                        return default(IAsyncResult);
                    }
                    return asyncResult;
                };
        var task = Task.Factory.FromAsync(beginConnect, _socket.EndConnect, this);
        task.ContinueWith(t => onConnected(true), TaskContinuationOptions.NotOnFaulted)
            .ContinueWith(t => onConnected(false), TaskContinuationOptions.OnlyOnFaulted);
        task.ContinueWith(t => onConnected(false), TaskContinuationOptions.OnlyOnFaulted);
    }
