    class Program
    {
        static void Main(string[] args)
        {
        TcpClient t = new TcpClient("www.microsoft.com", 80);
        Console.WriteLine(GetMyIp(t.Client.LocalEndPoint.AddressFamily));
        t.Close();
    }
    static private String GetMyIp(AddressFamily addr)
    {
        String ipAddress = System.Net.Dns.GetHostEntry(
            System.Net.Dns.GetHostName()
            )
            .AddressList.First(i => i.AddressFamily.Equals(addr)).ToString();
        return ipAddress;
    } 
}
