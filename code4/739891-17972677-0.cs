    System.Net.IPHostEntry host;
    string localIP = "?";
    host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
    foreach (System.Net.IPAddress ip in host.AddressList)
    {
        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        {
            localIP = ip.ToString();
            Console.WriteLine(localIP);
        }
    }
    Console.ReadLine();
    return;
