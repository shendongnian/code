    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static bool a = false;
            public static bool b = false;
            public static bool c = true;
            public static bool d = false;
    
            static void Main(string[] args)
            {
                oneOfThem();
                Console.Read();
            }
            public static void oneOfThem()
            {
                bool[] _bArr = { a , b , c , d };
                char[] _cArr = { 'a', 'b', 'c', 'd' };
                int i = 0;
                foreach (bool _bool in _bArr)
                {
                    if (_bool == true)
                    {
                        Console.WriteLine(_cArr[i] + " returned : True.");
                    }
                    i++;
                }
            }
        }
    }
