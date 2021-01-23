    class Program
    {
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern IntPtr memcpy(IntPtr dest, IntPtr src, uint count);
        static void Main(string[] args)
        {
            const int size = 200;
            IntPtr memorySource = Marshal.AllocHGlobal(size);
            IntPtr memoryTarget = Marshal.AllocHGlobal(size);
            memcpy(memorySource, memoryTarget, size);
        }
    }
