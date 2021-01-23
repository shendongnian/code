    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var html = @"
                                <h1>This is a Title</h1>
                                @Html.Partial(""MyPartialView"")
                            ";
    
                var itemRegex = new Regex(@"@Html.Partial\(""([a-zA-Z]+)""\)", RegexOptions.Compiled);
                html = itemRegex.Replace(html, "<h2>$1</h2>");
                
                Console.WriteLine(html);
                Console.ReadKey();
            }
        }
    }
