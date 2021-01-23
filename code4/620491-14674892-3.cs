    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace CSharpClient
    {
        class Program
        {
            [DllImport(
                "NativeDll.dll", 
                CharSet = CharSet.Ansi, 
                CallingConvention = CallingConvention.StdCall)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool NativeFunction(
                string in1,
                string in2,
                StringBuilder result, 
                int resultMaxSize);
    
            static void Main(string[] args)
            {
                var result = new StringBuilder(200);
                if (! NativeFunction("Hello", " world!", result, result.Capacity))
                {
                    Console.WriteLine("Error.");
                    return;
                }
    
                Console.WriteLine(result.ToString());
            }
        }
    }
