    using System;
    
    class Test
    {
        static void Main()
        {
            DateTime dateTime = new DateTime(2012, 2, 27, 0, 34, 45, 56);
            // Prints 12:34:45
            Console.WriteLine(dateTime.ToString("hh:mm:ss"));
        }
    }
