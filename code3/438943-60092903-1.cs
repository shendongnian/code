    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Net.NetworkInformation;
    var ipV4s = NetworkInterface.GetAllNetworkInterfaces()
        .Select(i => i.GetIPProperties().UnicastAddresses)
        .SelectMany(u => u)
        .Where(u => u.Address.AddressFamily == AddressFamily.InterNetwork)
        .Select(i => i.Address);
