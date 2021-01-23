    public static class NetworkInterfaces
    {
        public static NetworkInterface GetDefaultInterface()
        {
            var interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            foreach (var intf in interfaces)
            {
                if (intf.OperationalStatus != OperationalStatus.Up)
                {
                    continue;
                }
                if (intf.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    continue;
                }
                var properties = intf.GetIPProperties();
                if (properties == null)
                {
                    continue;
                }
                var gateways = properties.GatewayAddresses;
                if ((gateways == null) || (gateways.Count == 0))
                {
                    continue;
                }
                var addresses = properties.UnicastAddresses;
                if ((addresses == null) || (addresses.Count == 0))
                {
                    continue;
                }
                return intf;
            }
            return null;
        }
        public static IPAddress GetDefaultIPV4Address(NetworkInterface intf)
        {
            if (intf == null)
            {
                return null;
            }
            foreach (var address in intf.GetIPProperties().UnicastAddresses)
            {
                if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                {
                    continue;
                }
                if (address.IsTransient)
                {
                    continue;
                }
                return address.Address;
            }
            return null;
        }
    }
