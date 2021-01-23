    using System;
    
    class Test
    {
        static void Main()
        {
            string text = "/mercedes-benz/190-class/1993/";
            string[] bits = text.Split('/');
            foreach (string bit in bits)
            {
                Console.WriteLine("'{0}'", bit);
            }
        }
    }
