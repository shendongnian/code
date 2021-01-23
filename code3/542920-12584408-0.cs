    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i = 0;
                using (var obj = new TestObj())
                {
                    if (i == 0) goto Label;
                }
                Console.WriteLine("some code here");
            Label:
                Console.WriteLine("after label");
            Console.Read();
            }
        }
        class TestObj : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("disposed");
            }
        }
    }
