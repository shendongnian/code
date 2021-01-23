       class Program
        {
            static object lockObj = new object();
            static void Main(string[] args)
            {
                System.Threading.Thread t = new System.Threading.Thread(proc);
                System.Threading.Thread t2 = new System.Threading.Thread(proc);
                t.Start();
                t2.Start();
                t.Join();
                t2.Join();
                Console.WriteLine("Total locked up time = " + (LockWithCount.TotalWaitTicks / 10000) + "ms");
                Console.WriteLine("Total blocks = " + LockWithCount.TotalBlocks);
                Console.ReadLine();
            }
        
            static void proc()
            {
                for (int x = 0; x < 100; x++)
                {
                    using (new LockWithCount(lockObj))
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                }
            }
        }
    
    
