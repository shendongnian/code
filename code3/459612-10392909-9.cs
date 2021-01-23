    public Expression<Func<int[],bool>> GetExpression(Queue<string> input)
    {
    	var exp = input.Dequeue();
    	if (exp == "AND") return GetExpression(input).And(GetExpression(input));
    	else if (exp == "OR") return GetExpression(input).Or(GetExpression(input));
    	else return (test => test.Contains(Convert.ToInt32(exp)));
    }
