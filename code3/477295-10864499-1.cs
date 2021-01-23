    public Func<double, double> CreateExpressionForX(string expression)
    {
    
    	ExpressionContext context = new ExpressionContext();
    	// Define some variables
    	context.Variables["x"] = 0.0d;
    
    	// Use the variables in the expression
    	IDynamicExpression e = context.CompileDynamic(expression);
    
    
    	Func<double, double> expressionEvaluator = (double input) =>
    	{
    		content.Variables["x"] = input;
    		var result = (double)e.Evaluate();
    		return result;
    	}
    
    	return expressionEvaluator;
    }
    
    
    
    Func<double, double> expression = CreateExpressionForX("x^2 + x + 1");
    
    double result1 = expression(1); //3
    double result2 = expression(20.5); //441.75
    double result3 = expression(-10.5); //121.75
    Func<double, double> expression2 = CreateExpressionForX("3 * x + 10");
        
    double result4 = expression2(1); //13
    double result5 = expression2(20.5); //71.5
    double result6 = expression2(-10.5); //-21.5
