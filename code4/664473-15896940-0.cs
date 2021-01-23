        private class GCAnalyzer
        {
            private static int count = 0;
            ~GCAnalyzer()
            {
                Console.WriteLine("GC " + count);
                if (!AppDomain.CurrentDomain.IsFinalizingForUnload() &&!Environment.HasShutdownStarted)
                {
                    count++;
                    GC.ReRegisterForFinalize(this);                    
                }
            }
        }
        static void Main(string[] a)
        {
            new GCAnalyzer();
            Console.ReadKey();
            GC.Collect();
            Console.ReadKey();
            GC.Collect();
        }
