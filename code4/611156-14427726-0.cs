    var client = new ServiceReference1.MyServiceClient();
    client.OperationCompleted += ...;
    using (new OperationContextScope(client.InnerChannel))
    {
        OperationContext.Current.OutgoingMessageHeaders.Add(
            MessageHeader.CreateHeader(
                "headerName", "http://header.namespace", "the value"));
        client.OperationAsync(param1, param2);
    }
