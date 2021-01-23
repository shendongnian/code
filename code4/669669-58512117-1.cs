    var security = TransportSecurityBindingElement.CreateUserNameOverTransportBindingElement();
        security.IncludeTimestamp = false;
        security.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic256;
        security.MessageSecurityVersion = MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;
    var encoding = new TextMessageEncodingBindingElement();
    encoding.MessageVersion = MessageVersion.Soap11;
    var transport = new HttpsTransportBindingElement();
    transport.MaxReceivedMessageSize = 20000000; // 20 megs
    binding.Elements.Add(security);
    binding.Elements.Add(encoding);
    binding.Elements.Add(transport);
    RealTimeOnlineClient client = new RealTimeOnlineClient(binding,
        new EndpointAddress(url));
        client.ChannelFactory.Endpoint.EndpointBehaviors.Remove(client.ClientCredentials);
    client.ChannelFactory.Endpoint.EndpointBehaviors.Add(new CustomCredentials());
    client.ClientCredentials.UserName.UserName = username;
    client.ClientCredentials.UserName.Password = password;
