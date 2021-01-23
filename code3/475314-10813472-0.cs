    StringBuilder onlyNumber = new StringBuilder();
    foreach (char onlyNum in puzzleData)
    {
        if (Char.IsDigit(onlyNum))
        {
            onlyNumber.Append(onlyNum);
        }
    }
