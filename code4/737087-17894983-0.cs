    using System;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            // Avoid encoding issues in the source file itself...
            string firstLevel = "\u00c3\u00a2\u00c2\u0080\u00c2\u0099";
            string secondLevel = HackDecode(firstLevel);
            string thirdLevel = HackDecode(secondLevel);
            Console.WriteLine("{0:x}", (int) thirdLevel[0]); // 2019
        }
     
        // Converts a string to a byte array using ISO-8859-1, then *decodes*
        // it using UTF-8. Any use of this method indicates broken data to start
        // with. Ideally, the source of the error should be fixed.
        static string HackDecode(string input)
        {
            byte[] bytes = Encoding.GetEncoding(28591)
                                   .GetBytes(input);
            return Encoding.UTF8.GetString(bytes);
        }
    }
