    var stack = new Stack<char>();
    
    for (var i = input.Length - 1; i >= 0; i--)
    {
        if (!char.IsNumber(input[i]))
        {
            break;
        }
    
        stack.Push(input[i]);
    }
    
    var result = new string(stack.ToArray());
