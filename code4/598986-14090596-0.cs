    using System;
    
    class Test
    {
        static Test test;
        
        private int count = 0;
        
        ~Test()
        {
            count++;
            Console.WriteLine("Finalizer count: {0}", count);
            if (count == 1)
            {
                GC.ReRegisterForFinalize(this);
            }
            test = this;
        }
        
        static void Main()
        {
            new Test();
            Console.WriteLine("First collection...");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            Console.WriteLine("Second collection (nothing to collect)");
            GC.Collect();
            GC.WaitForPendingFinalizers();
    
            Test.test = null;
            Console.WriteLine("Third collection (cleared static variable)");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            Test.test = null;
            Console.WriteLine("Fourth collection (no more finalization...)");
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
