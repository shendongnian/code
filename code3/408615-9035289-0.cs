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
                        "".PadLeft(13, '*'), 
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
