    public Result CallServer()
    {
        var address = new EndpointAddress(url);
        var client = new AdminServiceClient(endpointConfig, address);
        using (new OperationContextScope(client.InnerChannel))
        {
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = GetHeader();
            var request = new MyRequest(...); 
            {
                context = context,
            };
            return client.GetDataFromServerAsync(request).GetAwaiter().GetResult();
        }
    }
