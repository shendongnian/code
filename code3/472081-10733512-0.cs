    int bestIndex = -1;
    int bestResult = -1;
    for(int i = 0; i < elements.Count; ++i)
    {
        int currentResult = eval(x, elements[i]);
        if (currentResult > bestResult)
        {
            bestResult = currentResult;
            bestIndex = i;
        }
    }
