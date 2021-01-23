    using System;
    using System.Diagnostics;
    using System.Text;
    
    class Test
    {
        static readonly string[] Bits = { 
            "small string",
            "string which is a bit longer",
            "stirng which is longer again to force yet another copy with any luck"
        };
        
        static readonly int ExpectedLength = string.Join("", Bits).Length;
        
        static void Main()        
        {
            Time(StringBuilderTest);
            Time(ConcatenateTest);
        }
        
        static void Time(Action action)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            // Make sure it's JITted
            action();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                action();
            }
            sw.Stop();
            Console.WriteLine("{0}: {1} millis", action.Method.Name,
                              (long) sw.Elapsed.TotalMilliseconds);
        }
        
        static void ConcatenateTest()
        {
            string x = "";
            foreach (string bit in Bits)
            {
                x += bit;
            }
            // Force a validation to prevent dodgy optimizations
            if (x.Length != ExpectedLength)
            {
                throw new Exception("Eek!");
            }
        }
    
        static void StringBuilderTest()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string bit in Bits)
            {
                builder.Append(bit);
            }
            string x = builder.ToString();
            // Force a validation to prevent dodgy optimizations
            if (x.Length != ExpectedLength)
            {
                throw new Exception("Eek!");
            }
        }
    }
