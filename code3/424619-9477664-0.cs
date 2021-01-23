            static void Main(string[] args)
        {
            ReadCountFromFile();
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(aTimer_Elapsed);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            Console.WriteLine("Press Enter To Exit The Program\n");
            Console.ReadLine();
            
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_DomainUnload);
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
                        Console.WriteLine("Count = {0}", count);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem reading file.");
            }
        }
        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            using (var file = File.Open(".\\mynumber.dat", FileMode.OpenOrCreate))
            {
                var buffer = BitConverter.GetBytes(count);
                file.Write(buffer, 0, buffer.Length);
            }
        }
