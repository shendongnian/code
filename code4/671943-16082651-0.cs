    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static string FilterText(string input)
            {
                // Replace % by spaces, then remove all spaces/tabs with Trim function.
                string filteredText = input.Replace("%", " ").Trim();
                // Parse the text.
                int number = Int32.Parse(filteredText);
                // Fix not expected values.
                number = (number < 0) ? 0 : number;
                number = (number > 100) ? 100 : number;
                return number + "%";
            }
            public static void Main(string[] args)
            {
                Console.WriteLine("\"100%\": \"" + FilterText("100%") + "\"");
                Console.WriteLine("\"  50%\t\t\": \"" + FilterText("  50%\t\t") + "\"");
                Console.WriteLine("\"0%\": \"" + FilterText("0%") + "\"");
                Console.WriteLine("\"150%\": \"" + FilterText("150%") + "\"");
                Console.WriteLine("\"   -06%  \t \": \"" + FilterText("   -06%  \t ") + "\"");
            }
        }
    }
