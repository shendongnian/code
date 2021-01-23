    using System;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                new Program().Run();
            }
            void Run()
            {
                if ("".Length > 0)
                {
                    Test t = new Test();
                    Trace.WriteLine(t.Property); // Make sure we use the property.
                }
            }
        }
        internal class Test
        {
            public int Property { get; set; }
        }
    }
