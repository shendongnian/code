    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var string1 = "500g Flour 14g Salt 7g Dry yeast 45ml Olive oil 309ml Water";
    
                var result = Regex.Replace(string1, @"\w(\d+)", Doubler, RegexOptions.Multiline);
    
                Console.WriteLine(result);
    
                Console.ReadKey();
            }
    
            private static string Doubler(Match match)
            {
                return (Convert.ToInt32(match.Value)*2).ToString();
            }
        }
    }
