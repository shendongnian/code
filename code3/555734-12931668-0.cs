    int SendCommand(int param)
    {
        ManualResetEvent mre = new ManualResetEvent(false);
        // this is the result which will be set in the callback
        int result = 0;
        // Send an async command with some data and specify a callback method
        rpc.SendAsync(data, (returnData) =>
                           {
                               // extract / process your return value and 
                               // assign it to an outer scope variable
                               result = returnData.IntValue;
                               // signal the blocked thread to continue
                               mre.Set();
                           });
        // wait for the callback
        mre.WaitOne();
        return result;
    }
