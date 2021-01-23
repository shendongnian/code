    public static ResponseType CallService(RequestType requestBody, NetworkCredential credential)
    {
        ResponseType response;
        using (var channelFactory = new ChannelFactory<IMyService>("BasicHttpBinding_IMyService"))
        {
            channelFactory.Credentials.Windows.ClientCredential = credential;
            var client = channelFactory.CreateChannel();
            var request = new MyRequest()
                {
                    MyService = requestBody
                };
            response = client.MyService(request).MyResponse1;
            ((IClientChannel)client).Close();
            channelFactory.Close();
        }
        return response;
    }
