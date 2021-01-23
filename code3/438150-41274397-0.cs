    public class Program
    {
        public static object _o = new object();
        public static void Main(string[] args)
        {
            PingReply pingResult = null;
            int i = 0;
            Task.Run(async () =>
            {
                var ii = 0;
                //no error handling, example only
                //no cancelling, example only 
                var ping = new System.Net.NetworkInformation.Ping();
                while (true)
                {
                    Console.WriteLine($"A: {ii} > {DateTime.Now.TimeOfDay}");
                    var localPingResult = await ping.SendPingAsync("duckduckgo.com");
                    Console.WriteLine($"A: {ii} < {DateTime.Now.TimeOfDay}, status: {localPingResult?.Status}");
                    lock (_o)
                    {
                        i = ii;
                        pingResult = localPingResult;
                    }
                    
                    await Task.Delay(1000);
                    ii++;
                }
            });
            Task.Run(async () =>
            {
                //no error handling, example only 
                while (true)
                {
                    await Task.Delay(2000);
                    lock (_o)
                    {
                        Console.WriteLine($"B: Checking at {DateTime.Now.TimeOfDay}, status no {i}: {pingResult?.Status}");
                    }
                }
            });
            Console.WriteLine("This is the end of Main()");
            Console.ReadLine();
        }
    }
