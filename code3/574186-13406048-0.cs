        static void Main(string[] args)
        {
            Console.WriteLine(AverageRoundTripTime("www.google.com", 100));
            Console.WriteLine(AverageRoundTripTime("www.stackoverflow.com", 100));
            Console.ReadKey();
        }
        static double AverageRoundTripTime(string host, int sampleSize)
        {
            ConcurrentBag<double> values = new ConcurrentBag<double>();
            Parallel.For(1, sampleSize, (x, y) => values.Add(Ping(host)));
            return values.Sum(x => x) / sampleSize;
        }
        static double Ping(string host)
        {
            var reply = new Ping().Send(host);
            if (reply != null)
                return reply.RoundtripTime;
            throw new Exception("denied");
        }
