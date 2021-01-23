    Action wrappedAction = () =>
    {
        // show your input
    };
    IAsyncResult result = wrappedAction.BeginInvoke(null, null);
    
    if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds))
    {
        /// the user supplied an input and closed the form
        wrappedAction.EndInvoke(result);
    }
    else
    {
        // the code has timed out so close your input and throw error
    }
