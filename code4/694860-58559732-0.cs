    var task = Task.Factory.StartNew(() =>
    {
        var tcs = new TaskCompletionSource<object>();
        var thread = new Thread(() =>
        {
            try
            {
                action();
                tcs.SetResult(new object());
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();
    }, cancellationToken);
