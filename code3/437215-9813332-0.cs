    byte IP1 = 192, IP2 = 168, IP3 = 0, IP4 = 0;
    int totalIPs = 65536;
    int littleEndian = IP4 + (IP3 << 8) + (IP2 << 16) + (IP1 << 24) + totalIPs;
    var bigEndian = BitConverter.GetBytes(littleEndian).Reverse().ToArray();
    Console.WriteLine(new System.Net.IPAddress(bigEndian));
