    class Program
    {
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
        static void Main()
        {
            const int size = 200;
            IntPtr memorySource = Marshal.AllocHGlobal(size);
            IntPtr memoryTarget = Marshal.AllocHGlobal(size);
            CopyMemory(memoryTarget,memorySource,size);
        }
    }
