    public static void DiceLoop(Func<int> getNext) 
    {
        int result = 0;
        for(int i = 0; i < maxDice; i++)
        {
            result += getNext();
        }
        Console.WriteLine (result);
    }
