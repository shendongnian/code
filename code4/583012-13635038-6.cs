    public static IPAddress GetDefaultGateway()
    {
        return NetworkInterface
            .GetAllNetworkInterfaces()
            .Where(n => n.OperationalStatus == OperationalStatus.Up)
            .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
            .Select(g => g?.Address)
            .Where(a => a != null)
             // .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
             // .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
            .FirstOrDefault();
    }
