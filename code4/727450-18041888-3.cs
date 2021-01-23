    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    
    namespace DLLCall
    {
        class Program
        {
            [DllImport("C:\\Devs\\C++\\Projects\\Interop\\InteropTestApp\\Debug\\InteropTestApp.dll")]
            public static extern IntPtr test();
    
            [DllImport("C:\\Devs\\C++\\Projects\\Interop\\InteropTestApp\\Debug\\InteropTestApp.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int ReleaseMemory(IntPtr ptr);
    
            static void Main(string[] args)
            {
                IntPtr ptr = test();
                int[] result = new int[5];
                Marshal.Copy(ptr, result, 0, 5);
    
                ReleaseMemory(ptr);
                
                Console.ReadKey();
            }
        }
    }
