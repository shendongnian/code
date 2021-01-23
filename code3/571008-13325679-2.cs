    class Program
    {
        public static double Evaluate(string expression)  
        {  
            using (var stringReader = new StringReader("<dummy/>"))
            {
                var navigator = new XPathDocument(stringReader).CreateNavigator();
                expression = Regex.Replace(expression, @"([\+\-\*])", " ${1} "); // add some space
                expression = expression.Replace("/", " div ").Replace("%", " mod ");
                return (double)navigator.Evaluate(string.Format("number({0})", expression));
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Evaluate("3*-2+1"));
        }
    }
