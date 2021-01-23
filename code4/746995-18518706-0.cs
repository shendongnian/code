    class Program
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentThread();
            
        [DllImport("kernel32.dll")]
        private static extern uint QueueUserAPC(ApcMethod pfnAPC, IntPtr hThread, UIntPtr dwData);
            
        private delegate void ApcMethod(UIntPtr dwParam);
            
        static void Main(string[] args)
        {
            IntPtr threadHandle = IntPtr.Zero;
            var threadHandleSet = new ManualResetEvent(false);
            var apcSet = new ManualResetEvent(false);
            var thread = new Thread(
                () =>
                {
                    Console.WriteLine("thread started");
                    threadHandle = GetCurrentThread();
                    threadHandleSet.Set();
                    apcSet.WaitOne();
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("thread waiting");
                        Thread.Sleep(1000);
                        Console.WriteLine("thread running");
                    }
                    Console.WriteLine("thread finished");
                });
            thread.Start();
            threadHandleSet.WaitOne();
            uint result = QueueUserAPC(DoApcCallback, threadHandle, UIntPtr.Zero);
            apcSet.Set();
            Console.ReadLine();
        }
    
        private static void DoApcCallback(UIntPtr dwParam)
        {
            Console.WriteLine("DoApcCallback");
        }
    }
