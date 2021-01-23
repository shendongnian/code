    using System;
    
    namespace SampleApplication
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                var input = "one,two,three,four,five,six";
    
                string [] words = input.Split(',');
    
                Console.WriteLine("Number of Words: {0}", words.Length);
    
                foreach (object value in words)
                {
                    Console.WriteLine(value.ToString());
                }
            }
        }
    }
