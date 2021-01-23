    using System;
    
    class Test
    {
        static void Main()
        {
            int x = 10;
            Action increment = () => x++;
            
            increment();
            increment();
            Console.WriteLine(x); // 12
        }
    }
