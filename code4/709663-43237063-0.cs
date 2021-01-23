    var timeOut = TimeSpan.FromSeconds(5);     
    var cancellationCompletionSource = new TaskCompletionSource<bool>();
    try
    {
        using (var cts = new CancellationTokenSource(timeOut))
        {
            using (var client = new TcpClient())
            {
                var task = client.ConnectAsync(hostUri, portNumber);
                using (cts.Token.Register(() => cancellationCompletionSource.TrySetResult(true)))
                {
                    if (task != await Task.WhenAny(task, cancellationCompletionSource.Task))
                    {
                        throw new OperationCanceledException(cts.Token);
                    }
                }
                ...
            }
        }
    }
    catch(OperationCanceledException)
    {
        ...
    }
