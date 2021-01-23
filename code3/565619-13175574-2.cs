    NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
    foreach (var adapter in interfaces)
    {
        var ipProps = adapter.GetIPProperties();
    
        foreach (var ip in ipProps.UnicastAddresses)
        {
            if ((adapter.OperationalStatus == OperationalStatus.Up)
            && (ip.Address.AddressFamily == AddressFamily.InterNetwork))
            {
                Console.Out.WriteLine(ip.Address.ToString() + "|" + adapter.Description.ToString());
            }
        }
    }
