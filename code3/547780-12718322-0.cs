    private void Waiter(int milliseconds)
    {
        asyncProcessor.Service1SoapClient sendReference;
        sendReference = new asyncProcessor.Service1SoapClient();
        sendReference.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
        sendReference.BeginLengthyProcedure(milliseconds, ServiceCallBack, sendReference);
    
    }
    
    private void ServiceCallBack(IAsyncResult result)
    {
        asyncProcessor.Service1SoapClient sendReference = result.AsyncState as asyncProcessor.Service1SoapClient;
        string strResult = sendReference.EndLengthyProcedure(result);
    }
