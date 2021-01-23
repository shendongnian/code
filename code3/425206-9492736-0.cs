        public static void Main()
        {
            var lockMe = new object();
            using (var latch = new ManualResetEvent(true))
            using (var fs = new FileStream(@"C:\Temp\Temp.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            using (var fsw = new FileSystemWatcher(@"C:\Temp\"))
            {
                fsw.Changed += (s, e) =>
                                   {
                                       lock (lockMe)
                                       {
                                           if (e.FullPath != @"C:\Temp\Temp.txt") return;
                                           latch.Set();
                                       }
                                   };
                using (var sr = new StreamReader(fs))
                    while (true)
                    {
                        latch.WaitOne();
                        lock (lockMe)
                        {
                            String line;
                            while ((line = sr.ReadLine()) != null)
                                Console.Out.WriteLine(line);
                            latch.Set();
                        }
                    }
            }
        }
