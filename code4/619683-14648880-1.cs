    ExpressionContext context = new ExpressionContext();
    //Tell FLEE to expect a DateTime result; if the expression evaluates otherwise, 
    //throws an ExpressionCompileException when compiling the expression
    context.Options.ResultType = typeof(DateTime);
    //Instruct FLEE to expose the `DateTime` static members and have 
    //them accessible via "DateTime".
    //This mimics the same exact C# syntax to access `DateTime.Now`
    context.Imports.AddType(typeof(DateTime), "DateTime");
    //Parse the expression, naturally the string would come from your data source
    IDynamicExpression expression = ExpressionFactory.CreateDynamic("DateTime.Now.AddDays(-7)", context);
    //I believe there's a syntax in full C# that lets you evaluate this 
    //with a generic flag, but in this build, I only have it return type 
    //`Object` so we cast (it does return a `DateTime` though)
    DateTime date = (DateTime)expression.Evaluate();
    Console.WriteLine(date); //January 25th (7 days ago for me!)
