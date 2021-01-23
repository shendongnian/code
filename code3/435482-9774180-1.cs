    //Your client type could be ICommunicationObject or ClientBase:
    var client = new YourServiceProxyType();
    try {
        var result = client.MakeCall();
        //do stuff with result...
        //Done with client. Close it:
        client.Close();
    }
    catch (Exception ex) {
        if (client.State != System.ServiceModel.CommunicationState.Closed)
            client.Abort();
    }
