    public static void DisplayDirectedBroadcastAddresses()
    {
    
        foreach (var iface in NetworkInterface.GetAllNetworkInterfaces()
                 .Where(c => c.NetworkInterfaceType != NetworkInterfaceType.Loopback))
        {
            Console.WriteLine(iface.Description);
            foreach (var ucastInfo in iface.GetIPProperties().UnicastAddresses
                     .Where(c => !c.Address.IsIPv6LinkLocal))
            {
                Console.WriteLine("\tIP       : {0}", ucastInfo.Address);
                Console.WriteLine("\tSubnet   : {0}", ucastInfo.IPv4Mask);
                byte[] ipAdressBytes = ucastInfo.Address.GetAddressBytes();
                byte[] subnetMaskBytes = ucastInfo.IPv4Mask.GetAddressBytes();
    
                if (ipAdressBytes.Length != subnetMaskBytes.Length) continue;
                    
                var broadcast = new byte[ipAdressBytes.Length];
                for (int i = 0; i < broadcast.Length; i++)
                {
                    broadcast[i] = (byte)(ipAdressBytes[i] | ~(subnetMaskBytes[i]));
                }
                Console.WriteLine("\tBroadcast: {0}", new IPAddress(broadcast).ToString());
            }
        }
                
    }
