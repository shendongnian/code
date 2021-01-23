    namespace RestSharp
    {
        public static class RestSharpEx
        {
            public static Task<string> ExecuteTask(this RestClient client, RestRequest request)
            {
                var tcs = new TaskCompletionSource<string>(TaskCreationOptions.AttachedToParent);
    
                client.ExecuteAsync(request, response =>
                {
                    if (response.ErrorException != null)
                        tcs.TrySetException(response.ErrorException);
                    else
                        tcs.TrySetResult(response.Content);
                });
    
                return tcs.Task;
            }
        }
    }
