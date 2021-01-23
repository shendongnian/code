    public static void ListenerCallback(IAsyncResult result)
    {
        var listenerClosure = (HttpListener)result.AsyncState;
        var contextClosure = listenerClosure.EndGetContext(result);
    
        // do not process request on the dispatcher thread, schedule it on ThreadPool
        // otherwise you will prevent other incoming requests from being dispatched
        ThreadPool.QueueUserWorkItem(
            ctx =>
            {
                var response = (HttpListenerResponse)ctx;
    
                using (var stream = ... )
                {
                    stream.CopyTo(response.ResponseStream);
                }
    
                response.Close();
            }, contextClosure.Response);
    }
