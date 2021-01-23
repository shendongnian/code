    string text = "(paid for)";
    
    Stack<int> parenthesis = new Stack<int>();
    int last = 0;
    
    for (int i = 0; i < text.Length; i++)
    {
    	if (text[i] == '(')
    		parenthesis.Push(i);
    	else if (text[i] == ')')
    	{
    		last = parenthesis.Pop();
    	}
    }
    
    if (last == 0)
    {
    	// The matching parenthesis was the first letter.
    }
