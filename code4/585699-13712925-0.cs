    public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
    {
       SessionScope scope = new SessionScope();
       OperationContext.Current.Extensions.Add( scope );
    }
