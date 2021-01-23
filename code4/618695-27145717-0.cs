    using(new OperationContextScope(client.InnerChannel)) 
    {
        // Add a SOAP Header to an outgoing request
        MessageHeader aMessageHeader = MessageHeader.CreateHeader("UserInfo", "http://tempuri.org", userInfo);
        OperationContext.Current.OutgoingMessageHeaders.Add(aMessageHeader);
    }
