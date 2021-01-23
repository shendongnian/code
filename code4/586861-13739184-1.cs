    using System;
    
    class Test
    {
        static void Main()
        {
            var bytes = new byte[4] { 0xE8, 0x03, 0x00, 0x00 };
            var convertedInt = BitConverter.ToInt32(bytes, 0);
            Console.WriteLine(convertedInt); // 1000
        }
    }
