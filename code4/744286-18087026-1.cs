    [StructLayout(LayoutKind.Sequential)]
    class MyClass
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int E { get; set; }
        public int F { get; set; }
        public int G { get; set; }
        public byte H { get; set; }
    }
    class Program
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        static extern IntPtr memcpy(IntPtr dest, IntPtr src, UIntPtr count);
        [DllImport("kernel32.dll", SetLastError = false)]
        static extern void CopyMemory(IntPtr dest, IntPtr src, UIntPtr count);
        static void Main()
        {
            MyClass mc = new MyClass { A = 1, B = 2, C = 3, D = 4, E = 5, F = 6, G = 7, H = 8 };
            MyClass mc2 = new MyClass();
            int size = Marshal.SizeOf(typeof(MyClass));
            var gc = GCHandle.Alloc(mc, GCHandleType.Pinned);
            var gc2 = GCHandle.Alloc(mc2, GCHandleType.Pinned);
            IntPtr dest = gc2.AddrOfPinnedObject();
            IntPtr src = gc.AddrOfPinnedObject();
            // Pre-caching
            memcpy(dest, src, (UIntPtr)size);
            CopyMemory(dest, src, (UIntPtr)size);
            UnsafeCopy(dest, src, size);
            UnsafeCopy8(dest, src, size);
            int cycles = 10000000;
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            var sw1 = Stopwatch.StartNew();
            for (int i = 0; i < cycles; i++)
            {
                memcpy(dest, src, (UIntPtr)size);
            }
            sw1.Stop();
            var sw2 = Stopwatch.StartNew();
            for (int i = 0; i < cycles; i++)
            {
                CopyMemory(dest, src, (UIntPtr)size);
            }
            sw2.Stop();
            var sw3 = Stopwatch.StartNew();
            for (int i = 0; i < cycles; i++)
            {
                UnsafeCopy(dest, src, size);
            }
            sw3.Stop();
            var sw4 = Stopwatch.StartNew();
            for (int i = 0; i < cycles; i++)
            {
                UnsafeCopy8(dest, src, size);
            }
            sw4.Stop();
            gc.Free();
            gc2.Free();
            Console.WriteLine("IntPtr.Size: {0}", IntPtr.Size);
            Console.WriteLine("memcpy:      {0}", sw1.ElapsedTicks);
            Console.WriteLine("CopyMemory:  {0}", sw2.ElapsedTicks);
            Console.WriteLine("UnsafeCopy:  {0}", sw3.ElapsedTicks);
            Console.WriteLine("UnsafeCopy8: {0}", sw4.ElapsedTicks);
            Console.ReadKey();
        }
        static unsafe void UnsafeCopy(IntPtr dest, IntPtr src, int size)
        {
            while (size >= sizeof(int))
            {
                *((int*)dest) = *((int*)src);
                dest = (IntPtr)(((byte*)dest) + sizeof(int));
                src = (IntPtr)(((byte*)src) + sizeof(int));
                size -= sizeof(int);
            }
            if (size >= sizeof(short))
            {
                *((short*)dest) = *((short*)src);
                dest = (IntPtr)(((byte*)dest) + sizeof(short));
                src = (IntPtr)(((byte*)src) + sizeof(short));
                size -= sizeof(short);
            }
            if (size == sizeof(byte))
            {
                *((byte*)dest) = *((byte*)src);
            }
        }
        static unsafe void UnsafeCopy8(IntPtr dest, IntPtr src, int size)
        {
            while (size >= sizeof(long))
            {
                *((long*)dest) = *((long*)src);
                dest = (IntPtr)(((byte*)dest) + sizeof(long));
                src = (IntPtr)(((byte*)src) + sizeof(long));
                size -= sizeof(long);
            }
            if (size >= sizeof(int))
            {
                *((int*)dest) = *((int*)src);
                dest = (IntPtr)(((byte*)dest) + sizeof(int));
                src = (IntPtr)(((byte*)src) + sizeof(int));
                size -= sizeof(int);
            }
            if (size >= sizeof(short))
            {
                *((short*)dest) = *((short*)src);
                dest = (IntPtr)(((byte*)dest) + sizeof(short));
                src = (IntPtr)(((byte*)src) + sizeof(short));
                size -= sizeof(short);
            }
            if (size == sizeof(byte))
            {
                *((byte*)dest) = *((byte*)src);
            }
        }
    }
