    public static void DiceLoop(Func<int,int> roller)
    {
        int result = 0, maxDice = 20;
        for(int i = 1; i <= maxDice; i++)
        {
            result += roller(i);
        }
        Console.WriteLine (result);
    }
