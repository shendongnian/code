    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
        // Authorize() returns a started
        // task that authenticates the user
        // if the result is false we should
        // return a 401 immediately
        // otherwise we can invoke the inner handler
        Task<bool> authenticationTask = Authorize(request);
        // attach a continuation...
        authenticationTask.ContinueWith(_ =>
        {
            if (authenticationTask.Result)
            {
                // authentication succeeded
                // so start the inner handler chain
                // and write the result to the
                // task completion source when done
                Task.Factory.StartNew(() => base.SendAsync(request, cancellationToken)
                    .ContinueWith(t => taskCompletionSource.SetResult(t.Result)));
            }
            else
            {
                // authentication failed
                // so complete the TCS immediately
                taskCompletionSource.SetResult(
                    new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
        });
        return taskCompletionSource.Task;
    }
