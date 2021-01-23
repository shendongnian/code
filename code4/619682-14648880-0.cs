    ExpressionContext context = new ExpressionContext();
    context.Options.ResultType = typeof(DateTime);
    context.Imports.AddType(typeof(DateTime), "DateTime");
    IDynamicExpression expression = ExpressionFactory.CreateDynamic("DateTime.Now.AddDays(-7)", context);
    DateTime date = (DateTime)expression.Evaluate();
    Console.WriteLine(date); //January 25th
