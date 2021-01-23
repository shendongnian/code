    public static IPAddress GetDefaultGateway()
    {
        IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
        var card = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();
        if(card == null) return null;
        var address = card.GetIPProperties().GatewayAddresses.FirstOrDefault();
        return address.Address;
    }
