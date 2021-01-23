using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                //Allocate exactly 64 bytes of unmanaged memory
                char* str = (char*)System.Runtime.InteropServices.Marshal.AllocHGlobal(64).ToPointer();
                str[0] = 'H';
                str[1] = 'i';
                str[2] = '!';
                str[3] = '\0';
                
                Console.WriteLine(System.Runtime.InteropServices.Marshal.PtrToStringAuto(new IntPtr(str)));
                System.Runtime.InteropServices.Marshal.FreeHGlobal(new IntPtr(str));
            }
            Console.ReadKey();
        }
    }
}
