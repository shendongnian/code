    using System.Net;
    using System.Net.NetworkInformation;
    using (Ping Packet = new Ping()) 
    {
        if (Packet.Send(IPAddress.Parse(IP), 1000, new byte[] { 0 }).Status ==   IPStatus.Success))
        {
           // ...
        }
    }
