    BigInteger lhs = new BigInteger(0);
    BigInteger rhs = new BigInteger(0);
    Wrapper<BigInteger> currentSide = new Wrapper<BigInteger>();
    
    currentSide.Value = lhs;
    
    for (int i = 0; i < txtResult.Text.Length; i++)
    {
        char currentCharacter = txtResult.Text[i];
    
        if (char.IsNumber(currentCharacter))
        {
            currentSide.Value += (int)char.GetNumericValue(currentCharacter);
        }
    }
