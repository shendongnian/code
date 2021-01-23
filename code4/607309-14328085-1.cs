        static void Main(string[] args) {
            IPSegment ip = new IPSegment("192.168.1.1","255.255.255.248");
            Console.WriteLine(ip.NumberOfHosts);
            Console.WriteLine(ip.NetworkAddress.ToIpString());
            Console.WriteLine(ip.BroadcastAddress.ToIpString());
            Console.WriteLine("===");
            foreach (var host in ip.Hosts()) {
                Console.WriteLine(host.ToIpString());
            }
            Console.ReadLine();
        }
