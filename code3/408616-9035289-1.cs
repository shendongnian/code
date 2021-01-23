    using System;
    
    class Program
    {
        static void Main()
        {
            var str = "1234567890123456";
            if (str.Length > 4)
            {
                Console.WriteLine(
                    string.Concat(
                        "".PadLeft(12, '*'), 
                        str.Substring(str.Length - 4)
                    )
                );
            }
            else
            {
                Console.WriteLine(str);
            }
        }
    }
