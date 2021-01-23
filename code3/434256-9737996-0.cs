    string sHostName = Dns.GetHostName();
    IPHostEntry ipE = Dns.GetHostByName(sHostName);
    IPAddress[] IpA = ipE.AddressList;
    for (int i = 0; i < IpA.Length; i++)
    {
        Console.WriteLine("IP Address {0}: {1} {2} ", i, IpA[i].ToString() , sHostName);
        string[] x = IpA[i].ToString().Split('.');
        Console.WriteLine("{0}.{1}.{2}.", x[0], x[1], x[2]);
    }
