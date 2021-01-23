    using System.Net.Sockets;
    using System.Net;
    using System.Net.NetworkInformation;
     
    string localNicMac = "00:00:00:11:22:33".Replace(":", "-"); // Parse doesn't like colons
     
    var mac = PhysicalAddress.Parse(localNicMac);
    var localNic =
    NetworkInterface.GetAllNetworkInterfaces()
    .Where(nic => nic.GetPhysicalAddress().Equals(mac)) // Must use .Equals, not ==
    .SingleOrDefault();
    if (localNic == null)
    {
    throw new ArgumentException("Local NIC with the specified MAC could not be found.");
    }
     
    var ips =
    localNic.GetIPProperties().UnicastAddresses
    .Select(x => x.Address);
