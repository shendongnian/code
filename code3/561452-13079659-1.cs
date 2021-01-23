    class Program
    {
        static void Main(string[] args)
        {
            SIMDVector4 a = SIMDVector4.Create(1, 2, 3, 4);
            SIMDVector4 b = SIMDVector4.Create(1, 2, 3, 4);
            SIMDVector4 c = a * b;
            Console.WriteLine();
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    unsafe struct SIMDVector4
    {
        private float* ptr;
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool VirtualFree(IntPtr lpAddress, UIntPtr dwSize,
           uint dwFreeType);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAlloc(IntPtr lpAddress, UIntPtr dwSize,
           AllocationType flAllocationType, MemoryProtection flProtect);
        [Flags()]
        public enum AllocationType : uint
        {
            COMMIT = 0x1000,
            RESERVE = 0x2000,
            RESET = 0x80000,
            LARGE_PAGES = 0x20000000,
            PHYSICAL = 0x400000,
            TOP_DOWN = 0x100000,
            WRITE_WATCH = 0x200000
        }
        [Flags()]
        public enum MemoryProtection : uint
        {
            EXECUTE = 0x10,
            EXECUTE_READ = 0x20,
            EXECUTE_READWRITE = 0x40,
            EXECUTE_WRITECOPY = 0x80,
            NOACCESS = 0x01,
            READONLY = 0x02,
            READWRITE = 0x04,
            WRITECOPY = 0x08,
            GUARD_Modifierflag = 0x100,
            NOCACHE_Modifierflag = 0x200,
            WRITECOMBINE_Modifierflag = 0x400
        }
        public static SIMDVector4 Create(float x, float y, float z, float w)
        {
            IntPtr ptr =  VirtualAlloc(IntPtr.Zero, new UIntPtr(16), AllocationType.COMMIT, MemoryProtection.READWRITE);
            return new SIMDVector4((float*)ptr.ToPointer());
        }
        public SIMDVector4(float* ptr)
        {
            this.ptr = ptr;
        }
        public float x
        {
            get
            {
                if (this.ptr == null)
                {
                    return 0f;
                }
                return *(ptr);
            }
            set
            {
                if (this.ptr != null)
                {
                    *(this.ptr) = value;
                }
            }
        }
        public float y
        {
            get
            {
                if (this.ptr == null)
                {
                    return 0f;
                }
                return *(ptr + 4);
            }
            set
            {
                if (this.ptr != null)
                {
                    *(this.ptr + 4) = value;
                }
            }
        }
        public float z
        {
            get
            {
                if (this.ptr == null)
                {
                    return 0f;
                }
                return *(ptr + 8);
            }
            set
            {
                if (this.ptr != null)
                {
                    *(this.ptr + 8) = value;
                }
            }
        }
        public float w
        {
            get
            {
                if (this.ptr == null)
                {
                    return 0f;
                }
                return *(ptr + 12);
            }
            set
            {
                if (this.ptr != null)
                {
                    *(this.ptr + 12) = value;
                }
            }
        }
        public void* Ptr
        {
            get
            {
                return this.ptr;
            }
        }
        public void Free()
        {
            if (this.ptr == null)
            {
                return;
            }
            VirtualFree(new IntPtr(this.ptr), new UIntPtr(16), 0);
        }
        public override string ToString()
        {
            return "X: " + x + ", Y: " + y + ", Z: " + z + ", W: " + w;
        }
        public static SIMDVector4 operator *(SIMDVector4 a, SIMDVector4 b)
        {
            SIMDVector4Mult(a.Ptr, b.ptr);
            return a;
        }
        [DllImport(@"C:\Users\xxx\Documents\Visual Studio 2010\Projects\TestDll\Debug\TestDll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern private static unsafe void SIMDVector4Mult(void* a, void* b);
        [DllImport(@"C:\Users\xxx\Documents\Visual Studio 2010\Projects\TestDll\Debug\TestDll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern private static unsafe void SIMDVector4Mult(ref SIMDVector4 a, ref SIMDVector4 b);
    }
}
    [DllImport("SIMDMathLibrary.dll", CallingConvention = CallingConvention.Cdecl )]
        extern private static unsafe void SIMDVector4Mult(IntPtr a, IntPtr b );
