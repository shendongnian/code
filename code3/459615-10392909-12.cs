    public Queue<string> ParseRPN(string input)
    {
        // improve the parsing into tokens here
    	var output = new Queue<string>();
    	var ops = new Stack<string>();
    	input = input.Replace("(","( ").Replace(")"," )");
    	var split = input.Split(' ');
    		
    	foreach (var token in split)
    	{
    		if (token == "AND" || token == "OR")
    		{
    			while (ops.Count > 0 && (ops.Peek() == "AND" || ops.Peek() == "OR"))
    			{
    				output.Enqueue(ops.Pop());
    			}
    			ops.Push(token);
    		}
    		else if (token == "(") ops.Push(token);
    		else if (token == ")")
    		{
    			while (ops.Count > 0 && ops.Peek() != "(")
    			{
    				output.Enqueue(ops.Pop());
    			}
    			ops.Pop();
    		}
    		else output.Enqueue(token); // it's a number		
    	}
    	
    	while (ops.Count > 0)
    	{
    		output.Enqueue(ops.Pop());
    	}
    		
    	return output;
    }
