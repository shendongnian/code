    using System;
    using System.Data;
    
    class Program
    {
        static void Main()
        {
            var result = new DataTable().Compute("(2*3)+6", null);
            Console.WriteLine(result);
        }
    }
