    class Program
    {
        private static DateTime _processStart;
        static int count = 1;
        const int TOTAL = 15;
        private static Timer aTimer;
        private static Thread _process;
        static void Main(string[] args)
        {
            _process = new Thread(DoProcess);
            _process.Start();
            Console.WriteLine("Press Enter To Exit The Program\n");
            Console.ReadLine();
            ProcessExit();
        }
        
        static void DoProcess()
        {
            _processStart = DateTime.Now;
            ReadCountFromFile();
            if (count < TOTAL)
            {
                Console.WriteLine("******START TIMER******");
                aTimer = new Timer();
                aTimer.Elapsed += aTimer_Elapsed;
                aTimer.Interval = 500;
                aTimer.Enabled = true;
                while (aTimer.Enabled)
                {
                    Thread.Sleep(1000);
                }
                Console.WriteLine("******END TIMER******");
                ProcessExit();
                DoProcess();
            }
        }
        private static void ReadCountFromFile()
        {
            try
            {
                if (File.Exists(".\\mynumber.dat"))
                {
                    using (var file = File.Open(".\\mynumber.dat", FileMode.Open))
                    {
                        byte[] bytes = new byte[4];
                        file.Read(bytes, 0, 4);
                        count = BitConverter.ToInt32(bytes, 0);
                        Console.WriteLine("Total count left is = {0} / Limit = {1} / Count  = {2}", TOTAL - count, TOTAL, count);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem reading file.");
            }
        }
        
        static void ProcessExit()
        {
            using (var file = File.Open(".\\mynumber.dat", FileMode.OpenOrCreate))
            {
                var buffer = BitConverter.GetBytes(count);
                file.Write(buffer, 0, buffer.Length);
            }
        }
        
        private static void aTimer_Elapsed(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Name is Yap {0}", e.SignalTime);
            if (count < TOTAL)
            {
                count += 1;
                Console.WriteLine("Count is {0}", count);
            }
            if (count > TOTAL || _processStart.AddSeconds(1) < DateTime.Now) 
            {
                aTimer.Enabled = false;
                Console.WriteLine("Timer is off at {0} count is {1}", e.SignalTime.TimeOfDay.ToString(),count);
            }
        }
    }
