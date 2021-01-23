    else if (IsAnOperator(input[j])) // if we have got an operator
    {
        if (operators.Count != 0 && IsHigherPrecedence(operators.Peek().ToCharArray()[0], input[j]))
        {
            while ( ( operators.Count != 0 && IsHigherPrecedence(operators.Peek().ToCharArray()[0], input[j]) )  )
            { 
                postfix += operators.Pop() + " "; 
            }
        }
        operators.Push(Char.ToString(input[j]));
    }
