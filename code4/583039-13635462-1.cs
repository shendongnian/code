    using System;
    
    class Test
    {
        private class CapturingClass
        {
            public int x;
            
            public void Execute()
            {
                x++;
            }
        }
        
        static void Main()
        {
            CapturingClass capture = new CapturingClass();
            capture.x = 10;
            Action increment = capture.Execute;
            
            increment();
            increment();
            Console.WriteLine(capture.x); // 12
        }
    }
