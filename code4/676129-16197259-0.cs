    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            var ipEndpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8098);
            var from = 0;
            var to = 500;
            Parallel.For(from, to, index =>
            {
                using (var client = new NetTcpTesterProxy(ipEndpoint))
                {
                    var id = client.GetId("test1", 3.314, 42);
                    var response = client.Get(id, "mirror", 4.123, 42);
                    var list = client.GetItems(id);
                }
            });
            sw.Stop();
            var msperop = sw.ElapsedMilliseconds / 1500.0;
            Console.WriteLine("tcp: {0}, {1}", sw.ElapsedMilliseconds, msperop);
            Thread.Sleep(5000);
            var pipeName = "DuoViaTestHost";
            sw = Stopwatch.StartNew();
            Parallel.For(from, to, index =>
            {
                using (var client = new NetNpTesterProxy(new NpEndPoint(pipeName)))
                {
                    var id = client.GetId("test1", 3.314, 42);
                    var response = client.Get(id, "mirror", 4.123, 42);
                    var list = client.GetItems(id);
                }
            });
            sw.Stop();
            msperop = sw.ElapsedMilliseconds / 1500.0;
            Console.WriteLine("pip: {0}, {1}", sw.ElapsedMilliseconds, msperop);
            Console.ReadLine();
        }
    }
