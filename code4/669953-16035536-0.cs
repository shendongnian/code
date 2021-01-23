    using System;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                bool b = true;
                MyStruct? s1 = getNullableStruct();
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < 10000000; i++)
                {
                    b &= (object)s1 == null; // Note: Redundant cast to object.
                }
                Console.WriteLine(sw.Elapsed);
                MyStruct s2 = getStruct();
                sw.Restart();
                for (int i = 0; i < 10000000; i++)
                {
                    b &= (object)s2 == null;
                }
                Console.WriteLine(sw.Elapsed);
            }
            private static MyStruct? getNullableStruct()
            {
                return null;
            }
            private static MyStruct getStruct()
            {
                return new MyStruct();
            }
        }
        public struct MyStruct {}
    }
