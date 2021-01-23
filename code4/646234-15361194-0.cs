    public void EndProcessRequest(IAsyncResult result)
    {
        ProcessRequestDelegate del = (ProcessrequestDelegate) result.AsyncState;
        object item = del.EndInvoke(result)
    }
