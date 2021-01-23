        public void Test()
        {
            long kbAtExecution = GC.GetTotalMemory(false) / 1024;
            // do stuff that uses memory here 
            long kbAfter1 = GC.GetTotalMemory(false) / 1024;
            long kbAfter2 = GC.GetTotalMemory(true) / 1024;
            
            Console.WriteLine(kbAtExecution + " Started with this kb.");
            Console.WriteLine(kbAfter1 + " After the test.");
            Console.WriteLine(kbAfter1 - kbAtExecution + " Amt. Added.");
            Console.WriteLine(kbAfter2 + " Amt. After Collection");
            Console.WriteLine(kbAfter2 - kbAfter1 + " Amt. Collected by GC.");         
        }
