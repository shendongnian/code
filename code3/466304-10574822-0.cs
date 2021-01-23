    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestByte
    {
        class Program
        {
            static void Main(string[] args)
            {
                for (int i = -255; i < 256; i++)
                {
                    byte b = (byte)i;
                    System.Console.WriteLine("i={0}, b={1}", i, b);
                }
            }
        }
    }
