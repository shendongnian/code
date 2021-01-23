    public static Task<TResult> ExecuteTask<TResult>(
        this IRestClient client, IRestRequest request, CancellationToken cancel = default(CancellationToken)
        ) where TResult : new()
    {
        var tcs = new TaskCompletionSource<TResult>();
        try {
            var async = client.ExecuteAsync<TResult>(request, (response, _) => {
                if (cancel.IsCancellationRequested || response == null)
                    return;
                if (response.StatusCode != HttpStatusCode.OK) {
                    tcs.TrySetException(new DropboxException(response));
                } else {
                    tcs.TrySetResult(response.Data);
                }
            });
            
            cancel.Register(() => {
                async.Abort();
                tcs.TrySetCanceled();
            });
        } catch (Exception ex) {
            tcs.TrySetException(ex);
        }
        
        return tcs.Task;
    }
    public static Task<IRestResponse> ExecuteTask(this IRestClient client, IRestRequest request, CancellationToken cancel = default(CancellationToken))
    {
        var tcs = new TaskCompletionSource<IRestResponse>();
        try {
            var async = client.ExecuteAsync<IRestResponse>(request, (response, _) => {
                if (cancel.IsCancellationRequested || response == null)
                    return;
                if (response.StatusCode != HttpStatusCode.OK) {
                    tcs.TrySetException(new DropboxException(response));
                } else {
                    tcs.TrySetResult(response);
                }
            });
            
            cancel.Register(() => {
                async.Abort();
                tcs.TrySetCanceled();
            });
        } catch (Exception ex) {
            tcs.TrySetException(ex);
        }
        
        return tcs.Task;
    }
