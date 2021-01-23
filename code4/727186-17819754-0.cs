        private static string Evaluate(string expression)
        {
            var blah = new PowerBuilderAssembly();
 
            return blah.EvaluateExpression(expression);
        }
 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
 
            var result = Evaluate("1 = 1");
        }
