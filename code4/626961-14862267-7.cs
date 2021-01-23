    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(uint dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern bool TerminateThread(IntPtr hThread, uint dwExitCode);
        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId();
        private static void Main(string[] args)
        {
            var t = new Thread(() =>
                {
                    Console.WriteLine(GetCurrentThreadId());
                    while (true)
                    {
                    }
                }) {Name = "test"};
            t.Start();
                
            Console.WriteLine("Thread Id " + t.ManagedThreadId);
            Console.WriteLine("Exited");
        }
    }
