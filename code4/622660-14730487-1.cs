    ExpressionContext context = new ExpressionContext();
    
    //Tell FLEE to expect a DateTime result; if the expression evaluates otherwise, 
    //throws an ExpressionCompileException when compiling the expression
    context.Options.ResultType = typeof(DateTime);
    
    //Instruct FLEE to expose the `DateTime` static members and have 
    //them accessible via "DateTime".
    //This mimics the same exact C# syntax to access `DateTime.Now`
    context.Imports.AddType(typeof(DateTime), "DateTime");
    context.Imports.AddType(typeof(CustomFunctions));
    
    //Expose your key variables like HireDate and EnrollmentDate
    context.Variables["HireDate"] = GetHireDate(); //DateTime I suppose
    context.Variables["EnrollmentDate"] = GetEnrollmentDate(); //DateTime I suppose
    
    //Parse the expression, naturally the string would come from your data source
    IGenericExpression<DateTime> expression = context.CompileGeneric<DateTime>(GetYourRule(), context);
    
    DateTime date = expression.Evaluate();
