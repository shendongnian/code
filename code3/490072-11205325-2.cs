    using System;
    using System.Runtime.InteropServices;
    [StructLayout(LayoutKind.Explicit)]
    unsafe struct sample
    {
        [FieldOffset(0)] public int @in;
        [FieldOffset(4)] public fixed byte arr[32];
        [FieldOffset(36)] public fixed int arr2[4];
        [FieldOffset(52)] public float fl;    
    }
    
    static class Program
    {
        unsafe static void Main()
        {
            byte[] buffer = new byte[56];
            new Random().NextBytes(buffer); // some data...
    
            sample result;
            fixed(byte* tmp = buffer)
            {
                sample* ptr = (sample*) tmp;
                result = ptr[0];
            }
    
            Console.WriteLine(result.@in);
            Console.WriteLine(result.fl);
        }    
    }
