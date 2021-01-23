    void Getproducts(string filter, string augument, EventHandler<GetCompletedEventArgs> callback)
    {
        var tcs = new TaskCompletionSource<bool>();
        _serviceclient.GetAsyncGetproducts(filter, argument, args =>
        {
            callback(args);
            tcs.SetResult(true);
        });
        tcs.Task.Wait();
    }
