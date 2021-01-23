    //Client code:
    MessageHeader<Guid> tokenHeader = new MessageHeader<Guid>(someGuid);
    MyContractClient proxy = new MyContractClient();
    using(OperationContextScope contextScope =
                      new OperationContextScope(proxy.InnerChannel))
    {
       OperationContext.Current.OutgoingMessageHeaders.Add(
                      tokenHeader .GetUntypedHeader("Guid","System"));
       proxy.MyMethod();
    }
    proxy.Close();
