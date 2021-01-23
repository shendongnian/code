    int[] allPossibleNumbers = Enumerable.Range(1, maxNumber).ToArray();
    int[] picked = new int[numberToPick];
    for (int i = 0; i < numberToPick; i++)
    {
        int index = r.Next(i, maxNumber);
        picked[i] = allPossibleNumbers[index];
        allPossibleNumbers[index] = allPossibleNumbers[i];
    }
