    Action<int> addToCurrentSide;
    
    BigInteger lhs = new BigInteger(0);
    BigInteger rhs = new BigInteger(0);
    addToCurrentSide = x => lhs += x;
    for (int i = 0; i < txtResult.Text.Length; i++)
    {
        char currentCharacter = txtResult.Text[i];
        if (char.IsNumber(currentCharacter))
        {
            char currentCharacter = txtResult.Text[i];
            addToCurrentSide((int)char.GetNumericValue(currentCharacter));
        }
    }
