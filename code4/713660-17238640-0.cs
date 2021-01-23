    public object BeforeSendRequest(
        ref System.ServiceModel.Channels.Message request,
        System.ServiceModel.IClientChannel channel)
    {
        var httpRequestMessage = new HttpRequestMessageProperty();
        httpRequestMessage.Headers.Add("connection", "closed");
        request.Properties.Add(
            HttpRequestMessageProperty.Name, httpRequestMessage);
        return null;
    }
