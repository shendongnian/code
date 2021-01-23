    using System;
    using System.Runtime.InteropServices;
    namespace ManagedClient
    {
        class Program
        {
            [DllImport("UnmanagedDll.dll", CallingConvention = CallingConvention.StdCall)]
            private static extern int UseFloats([MarshalAs(UnmanagedType.LPArray)] IntPtr[] raws);
            static void Main(string[] args)
            {
                float[][] data =
                {
                    new[] { 0.0f, 0.1f, 0.2f, 0.3f, 0.4f },
                    new[] { 1.0f, 1.1f, 1.2f, 1.3f },
                    new[] { 2.0f },
                    new[] { 3.0f, 3.1f }
                };
                var handles = new GCHandle[data.Length];
                var pointers = new IntPtr[data.Length];
                try
                {
                    for (int i = 0; i < data.Length; ++i)
                    {
                        var h = GCHandle.Alloc(data[i], GCHandleType.Pinned);
                        handles[i] = h;
                        pointers[i] = h.AddrOfPinnedObject();
                    }
                    UseFloats(pointers);
                }
                finally
                {
                    for (int i = 0; i < handles.Length; ++i)
                    {
                        if (handles[i].IsAllocated)
                        {
                            handles[i].Free();
                        }
                    }
                }
            }
        }
    }
