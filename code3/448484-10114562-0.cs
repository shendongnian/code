    [ServiceContract]
    public interface IMyService
    {
        [OperationContract(AsyncPattern=true)]
        IAsyncResult BeginDoSomething();
        SomeResultType EndDoSomething(IAsyncResult result);
    }
    // Somewhere in the client app you store your channel factory (these are "expensive", these you cache)
    ChannelFactory<IMyService> channelFactory = new ChannelFactory<IMyService>();
    public void MyClientMethod()
    {
       // Create a client channel
       IMyService myServiceChannel = channelFactory.CreateChannel();
       // Use TPL's FromAsync to invoke the async WCF call and wrap that up with the familiar Task API
       Task<SomeResultType>.Factory.FromAsync(myServiceChannel.BeginDoSomething
                                              myServiceChannel.EndDoSomething,
                                              null)
                                   .ContinueWith(antecdent =>
                                   {
                                        try
                                        {
                                            // NOTE: exception will be thrown here if operation failed
                                            SomeResultType result = antecedent.Result;
                                        
                                            // ... continue processing the result ...
                                        }
                                        finally
                                        {
                                            // NOTE: depending on your configuration you might want to watch for errors and .Abort() here too
                                            ((IClientChannel)myServiceChannel).Close();
                                        }
                                   });      
    }
