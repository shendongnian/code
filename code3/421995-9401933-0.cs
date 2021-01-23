    using System;
    using System.Web;
    
    namespace htmlencode
    {
        class Program
        {
            static void Main(string[] args)
            {
                var encoded = HttpUtility.HtmlEncode("&#160;");
                var decoded = HttpUtility.HtmlDecode("&amp;#160;");
                Console.WriteLine("Encoded: " + encoded); //Prints &amp;#160;
                Console.WriteLine("Decoded: " + decoded); //Prints &#160;
                Console.ReadLine();
            }
        }
    }
