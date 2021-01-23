    using System;
    namespace BitConverterTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                UInt32 u32 = 0x01020304;
                byte[] u32ArrayLittle = {0x04, 0x03, 0x02, 0x01};
                byte[] u32ArrayBig = {0x01, 0x02, 0x03, 0x04};
                if (BitConverter.IsLittleEndian)
                {
                    if (BitConverter.ToUInt32(u32ArrayLittle, 0) != u32)
                    {
                        throw new Exception("Failed to convert the Little endian bytes");
                    }
                    Array.Reverse(u32ArrayBig); // convert the bytes to LittleEndian since that is our architecture.
                    if (BitConverter.ToUInt32(u32ArrayBig, 0) != u32)
                    {
                        throw new Exception("Failed to convert the Little endian bytes");
                    }
                } else
                {
                    Array.Reverse(u32ArrayLittle); // we are on a big endian platform
                    if (BitConverter.ToUInt32(u32ArrayLittle, 0) != u32)
                    {
                        throw new Exception("Failed to convert the Little endian bytes");
                    }
                    if (BitConverter.ToUInt32(u32ArrayBig, 0) != u32)
                    {
                        throw new Exception("Failed to convert the Little endian bytes");
                    }
                }
            }
        }
    }
