    public static void GetDefaultIp()
    {
        NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface adapter in adapters)
        {
            if (adapter.OperationalStatus == OperationalStatus.Up && adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet) 
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                foreach (var x in properties.UnicastAddresses)
                {
                    if (x.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        Console.WriteLine(" IPAddress ........ : {0:x}", x.Address.ToString());
                }
            }
        }
    }
