    public DTO_Echo_Response SendEcho(DTO_Echo_Request request)
    {
        return Process(() => Proxy.SendEcho(request));
    }
    
    public TResult Process<TResult>(Func<TResult> myFunction)
    {
        try
        {
            return myFunction();
        }
        catch (System.ServiceModel.CommunicationException)
        {
            throw new Communication_Error("Communication Error");
        }
    }
