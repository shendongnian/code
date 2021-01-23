    int[] allPossibleNumbers = Enumerable.Range(1, 37).ToArray();
    int[] lotteryNumber = new int[7];
    for (int i = 0; i < 7; i++)
    {
        int index = r.Next(i, 37);
        lotteryNumber[i] = allPossibleNumbers[index];
        allPossibleNumbers[index] = allPossibleNumbers[i];
        // This step not necessary, but allows you to reuse allPossibleNumbers
        // rather than generating a fresh one every time.
        // allPossibleNumbers[i] = lotteryNumber[i];
    }
