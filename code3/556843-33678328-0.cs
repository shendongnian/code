    using System.Net;
    foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces()) {
        Debug.WriteLine(netInterface.Name); // Name
        Debug.WriteLine(netInterface.Speed); // Speed
        Debug.WriteLine(netInterface.GetPhysicalAddress().ToString()); // MAC
    }
