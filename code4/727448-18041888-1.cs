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
            [DllImport("<path to the DLL>\\InteropTestApp.dll")]
            public static extern IntPtr test();
    
            static void Main(string[] args)
            {
                IntPtr ptr = test();
                int[] result = new int[5];
                Marshal.Copy(ptr, result, 0, 5);
                Console.ReadKey();
            }
        }
    }
