    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(5000); // Test it with 5 Seconds, set a window to foreground, and you see it works!
            IntPtr hWnd = GetForegroundWindow();
            uint procId = 0;
            GetWindowThreadProcessId(hWnd, out procId);
            var proc = Process.GetProcessById((int)procId);
            Console.WriteLine(proc.MainModule);
            Console.ReadKey();
        }
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    }
