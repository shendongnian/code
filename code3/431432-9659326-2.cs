    using System;
    
    class Test
    {
        static void Main() 
        {
            string before = "xyz @ abc@123";
            string after = before.Replace(" @ ", "");
            Console.WriteLine(after); // Prints xyzabc@123
        }
    }
