    int[] allPossibleNumbers = Enumerable.Range(1, maxNumber).ToArray();
    for (int i = 0; i < numberToPick; i++)
    {
        int index = r.Next(i, maxNumber);
        int temp = allPossibleNumbers[index];
        allPossibleNumbers[index] = allPossibleNumbers[i];
        allPossibleNumbers[i] = temp;
    }
    int[] selectedNumbers = allPossibleNumbers.Take(numberToPick).ToArray();
