    var sweeps = new List<int>();
    
    for (int i = 1; i < 6; i++)
    {
        for (int j = 0; j < 100; j++)
        {
            sweeps.Add(i);
        }
    }
    
    for (int i = 6; i <= 12; i++)
    {
        sweeps.Add(i);
    }
    
    var count = sweeps.Count;
    
    for (int i = 0; i < numberOfDice; i++)
    {
        int roll = sweeps[rnd.Next(1, count)];
        total += roll;
    
        result.AppendFormat("Congrats..!!! You got Dice {0:00}:\t{1}\n", i + 1, roll);
    }
