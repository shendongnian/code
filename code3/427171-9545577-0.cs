    static void Main(string[] args)
    {
        var expressions = new List<string>
                                {
                                    "3 * 5",
                                    "Log10(50)",
                                    "Parameters!Greeting + \" World!\""
                                };
    
        // An ExpressionMeta contains the expressions and extensions to be compiled.
        var meta = new ExpressionMeta("VisualBasic");
    
        // Add the expressions to be compiled.
        foreach(var expression in expressions)
            meta.AddExpression(expression);
    
        // Add the extensions to be compiled.
        var extension = new Dictionary<string, string> {{"Greeting", "Hello"}};
        meta.AddExtensionIgnoreAssembly(new Extension("Parameters", extension));
    
        // Compile the expressions
        using(var evaluator = meta.Compile())
        {
            // Evaluate the expression
            foreach(var expression in expressions)
                Console.WriteLine("{0}", evaluator.Evaluate(expression));
        }
    }
