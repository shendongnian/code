    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Runtime.ConstrainedExecution;
    
    
    namespace ConsoleApplication1
    {
        class Program
        {
            unsafe static void Main(string[] args)
            {
                using (AlignedBlock block = new AlignedBlock(SIMDVector4.Sizeof, AlignedBlock.AllocationGranularity / SIMDVector4.Sizeof))
                {
                    for (int index = 0; index < block.Count; index++)
                    {
                        SIMDVector4.Create(block[index], 1, 2, 3, 4);
                    }
    
                    SIMDVector4 a = SIMDVector4.Create(block[0], 1, 2, 3, 4);
                    SIMDVector4 b = SIMDVector4.Create(block[1], 1, 2, 3, 4);
                    SIMDVector4 c = SIMDVector4.Create(block[2], 5, 6, 7, 8);
                    SIMDVector4 d = a * b * c;
                    Console.WriteLine(d.ToString());
                }
    
                Console.ReadLine();
            }
        }
    
        public sealed unsafe class AlignedBlock : CriticalFinalizerObject, IDisposable
        {
            private void* ptr;
            
            static AlignedBlock()
            {
                SYSTEM_INFO info = new SYSTEM_INFO();
                NativeMethods.GetSystemInfo(ref info);
                PageSize = (int)info.dwPageSize;
                AllocationGranularity = (int)info.dwAllocationGranularity;
            }
    
            public AlignedBlock(int itemSize, int count)
            {
                this.ItemSize = itemSize; 
                this.Count = count;
                ptr = NativeMethods.VirtualAlloc(IntPtr.Zero, new UIntPtr((uint)this.ByteSize), AllocationType.COMMIT, MemoryProtection.READWRITE).ToPointer();
            }
    
    
            ~AlignedBlock()
            {
                this.Dispose();
            }
    
            public static int PageSize { get; private set; }
            public static int AllocationGranularity { get; private set; }
            public int ItemSize { get; private set; }
            public int Count { get; private set; }
            public int ByteSize
            {
                get
                {
                    return this.Count * this.ItemSize;
                }
            }
    
            public void* this[int index]
            {
                get
                {
                    int offset = this.ItemSize * index;
                    return ((byte*) this.ptr) + offset;
                }
            }
    
            public void Dispose()
            {
                bool result = NativeMethods.VirtualFree(new IntPtr(this.ptr), new UIntPtr(0), 0x8000);
                this.ptr = null;
            }
        }
    
        [StructLayout(LayoutKind.Sequential)]
        unsafe struct SIMDVector4
        {
            public const int Sizeof = 16;
            private float* ptr;
    
            public static SIMDVector4 Create(void* ptr, float x, float y, float z, float w)
            {
                float* value = (float*)ptr;
    
                SIMDVector4 vector = new SIMDVector4(value);
                *value = x;
                value++;
                *value = y;
                value++;
                *value = z;
                value++;
                *value = w;
                value++;
                return vector;
            }
    
            private SIMDVector4(float* ptr)
            {
                this.ptr = ptr;
            }
    
            public bool IsEmpty
            {
                get
                {
                    return this.ptr == null;
                }
            }
            public float x
            {
                get
                {
                    if (this.IsEmpty)
                    {
                        return 0f;
                    }
    
                    return *(ptr);
                }
    
                set
                {
                    if (!this.IsEmpty)
                    {
                        *(this.ptr) = value;
                    }
                }
    
            }
            public float y
            {
                get
                {
                    if (this.IsEmpty)
                    {
                        return 0f;
                    }
    
                    return *(ptr + 1);
                }
    
                set
                {
                    if (!this.IsEmpty)
                    {
                        *(this.ptr + 1) = value;
                    }
                }
    
            }
            public float z
            {
                get
                {
                    if (this.IsEmpty)
                    {
                        return 0f;
                    }
    
                    return *(ptr + 2);
                }
    
                set
                {
                    if (!this.IsEmpty)
                    {
                        *(this.ptr + 2) = value;
                    }
                }
    
            }
            public float w
            {
                get
                {
                    if (this.IsEmpty)
                    {
                        return 0f;
                    }
    
                    return *(ptr + 3);
                }
    
                set
                {
                    if (!this.IsEmpty)
                    {
                        *(this.ptr + 3) = value;
                    }
                }
            }
    
            public override string ToString()
            {
                return "X: " + x + ", Y: " + y + ", Z: " + z + ", W: " + w;
            }
    
    
            public static SIMDVector4 operator *(SIMDVector4 a, SIMDVector4 b)
            {
    
                SIMDVector4Mult(a.ptr, b.ptr);
                return new SIMDVector4(a.ptr);
            }
    
            [DllImport(@"C:\Users\xxx\Documents\Visual Studio 2010\Projects\TestDll\Debug\TestDll.dll", CallingConvention = CallingConvention.Cdecl)]
            extern private static unsafe void SIMDVector4Mult(void* a, void* b);
        }
    
        internal static class NativeMethods
        {
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool VirtualFree(IntPtr lpAddress, UIntPtr dwSize,
                   uint dwFreeType);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr VirtualAlloc(IntPtr lpAddress, UIntPtr dwSize,
                   AllocationType flAllocationType, MemoryProtection flProtect);
    
            [DllImport("kernel32.dll")]
            public static extern void GetSystemInfo([MarshalAs(UnmanagedType.Struct)] ref SYSTEM_INFO lpSystemInfo);
    
        }
        
        
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO
        {
            internal _PROCESSOR_INFO_UNION uProcessorInfo;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public IntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort dwProcessorLevel;
            public ushort dwProcessorRevision;
        }
    
        [StructLayout(LayoutKind.Explicit)]
        public struct _PROCESSOR_INFO_UNION
        {
            [FieldOffset(0)]
            internal uint dwOemId;
            [FieldOffset(0)]
            internal ushort wProcessorArchitecture;
            [FieldOffset(2)]
            internal ushort wReserved;
        }
        
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
    }   
