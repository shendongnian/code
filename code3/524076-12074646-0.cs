    using System;
    
    class Test
    {
        static void Main()
        {
            object converted = Convert.ChangeType("10", typeof(int?));
            Console.WriteLine(converted);
        }
    }
