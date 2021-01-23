    class Program
    {
        public bool Flag { get; set; }
        public void VolatilityTest()
        {
            bool work = false;
            while (!Flag)
            {
                work = !work; // fake work simulation
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            var t = new Thread(p.VolatilityTest);
            t.Start();
            Thread.Sleep(1000);
            p.Flag = true;
            t.Join();
        }
    }
