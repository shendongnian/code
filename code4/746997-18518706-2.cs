    class Program
    {
        [DllImport("kernel32.dll", EntryPoint = "DuplicateHandle", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern bool DuplicateHandle([In] System.IntPtr hSourceProcessHandle, [In] System.IntPtr hSourceHandle, [In] System.IntPtr hTargetProcessHandle, out System.IntPtr lpTargetHandle, uint dwDesiredAccess, [MarshalAsAttribute(UnmanagedType.Bool)] bool bInheritHandle, uint dwOptions);
    
        [DllImport("kernel32.dll", EntryPoint = "GetCurrentProcess", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr GetCurrentProcess();
            
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentThread();
            
        [DllImport("kernel32.dll")]
        private static extern uint QueueUserAPC(ApcMethod pfnAPC, IntPtr hThread, UIntPtr dwData);
            
        private delegate void ApcMethod(UIntPtr dwParam);
            
        static void Main(string[] args)
        {
            Console.WriteLine("Main: " + Thread.CurrentThread.ManagedThreadId);
            IntPtr threadHandle = IntPtr.Zero;
            var threadHandleSet = new ManualResetEvent(false);
            var apcSet = new ManualResetEvent(false);
            var thread = new Thread(
                () =>
                {
                    Console.WriteLine("thread started");
                    threadHandle = GetCurrentThread();
                    DuplicateHandle(GetCurrentProcess(), GetCurrentThread(), GetCurrentProcess(), out threadHandle, 0, false, 2);
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
            Console.WriteLine("DoApcCallback: " + Thread.CurrentThread.ManagedThreadId);
        }
    
    }
