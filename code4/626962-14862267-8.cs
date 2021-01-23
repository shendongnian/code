    internal class Program
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(uint dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern bool TerminateThread(IntPtr hThread, uint dwExitCode);
        private static void Main(string[] args)
        {
            var t = new Thread(() =>
                {
                    while (true)
                    {
                    }
                }) {Name = "test"};
            t.Start();
                
            Console.WriteLine("Exited");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            foreach (ProcessThread pt in Process.GetCurrentProcess().Threads)
            {
                IntPtr ptrThread = OpenThread(1, false, (uint)pt.Id);
                if (AppDomain.GetCurrentThreadId() != pt.Id)
                {
                    try
                    {
                        TerminateThread(ptrThread, 1);
                        Console.Out.Write(". Thread killed.\n");
                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(e.ToString());
                    }
                }
                else
                    Console.Out.Write(". Not killing... It's the current thread!\n");
            }
        }
    }
