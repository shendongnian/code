    public static IPAddress GetDefaultGateway()
    {
        var card = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();
        if(card == null) return null;
        var address = card.GetIPProperties().GatewayAddresses.FirstOrDefault();
        return address.Address;
    }
