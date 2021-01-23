    public IMessage SyncProcessMessage(IMessage msg)
    {
        var mcm = msg as IMethodCallMessage;
        var cancel = OnPreProcessing(ref mcm);
        var retMsg = cancel ? /*IMethodReturnMessage for cancelation*/ : _NextSink.SyncProcessMessage(msg) as IMethodReturnMessage;
        OnPostProcessing(mcm, ref retMsg);
        return retMsg;
    }
