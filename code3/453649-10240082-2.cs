using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace ConsoleApplication7
{
    class Program
    {
        [DllImport("mallocer.dll", CallingConvention=CallingConvention.Cdecl)]
        static extern IntPtr alMlc(int size, int alignment);
        static void Main(string[] args)
        {
            unsafe
            {
                //Allocate exactly 64 bytes of unmanaged memory, aligned at 64 bytes
                char* str = (char*)alMlc(64,64).ToPointer();
                str[0] = 'H';
                str[1] = 'i';
                str[2] = '!';
                str[3] = '\0';
                
                Console.WriteLine(System.Runtime.InteropServices.Marshal.PtrToStringAuto(new IntPtr(str)));
              
            }
            Console.ReadKey();
        }
    }
}
