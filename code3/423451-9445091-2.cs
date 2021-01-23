    using System;
    using System.Text.RegularExpressions;
    
    namespace RegexTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var expressions = new string[] {
                    "((2+3.1)/2)*4.456",
                    "1",
                    "(2)",
                    "2+2",
                    "(1+(2+3))",
                    "-2*(2+-2)",
                    "1+(3/(2+7-(4+3)))",
                    "1-",
                    "2+2)",
                    "(2+2",
                    "(1+(2+3)",
                };
    
                var regex = new Regex(@"(?x)
                    ^
                    (?> (?<p> \( )* (?>-?\d+(?:\.\d+)?) (?<-p> \) )* )
                    (?>(?:
        	            [-+*/]
        	            (?> (?<p> \( )* (?>-?\d+(?:\.\d+)?) (?<-p> \) )* )
                    )*)
                    (?(p)(?!))
                    $
                ");
    
                foreach (var expr in expressions)
                {
                    Console.WriteLine("Expression: " + expr);
                    Console.WriteLine("    Result: " + (regex.IsMatch(expr) ? "Matched" : "Failed"));
                }
            }
        }
    }
