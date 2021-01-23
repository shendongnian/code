    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] bytes = new byte[] { 0xff, 0x00, 0xff, 0xff, 0x00, 0xff, 0x00, 0xff, 0x00, 0xff, 0x00, 0xff, };
                foreach (var b in BitReader(bytes, 3))
                {
                    Console.WriteLine(b);
                }
            }
            public static IEnumerable<byte> BitReader(IEnumerable<byte> bytes, int stride)
            {
                int bit = 0;
                foreach (var b in bytes)
                {
                    while (true)
                    {
                        yield return (byte)(((b & (1 << bit)) != 0) ? 1 : 0);
                        bit += stride;
                        if (bit > 7)
                        {
                            bit %= 8;
                            break;
                        }
                    }
                }
            }
        }
    }
