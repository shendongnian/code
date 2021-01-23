    using System;
    
    class Test
    {
        unsafe static void Main()
        {
            byte[] rawData = new byte[1024];
            rawData[0] = 1;
            rawData[1] = 2;
    
            fixed (byte* bytePtr = rawData)
            {
                int* intPtr = (int*) bytePtr;
                Console.WriteLine(intPtr[0]); // Prints 513 on my box
            }
        }
    }
