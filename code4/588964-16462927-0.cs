        int i = 0;
        while (i <= 1)
        {
            int thisThrow = DiceRandom.Next(1, 6);
            DiceThrow[0 + i] += thisThrow;
            Console.ReadLine();
            Console.Write(Player[0 + i] + " rolled a " + thisThrow);
            if (thisThrow != 6) i++;
        }
        Console.ReadLine();
        PlayerTotal[0] += DiceThrow[0];
        PlayerTotal[1] += DiceThrow[1];
        Console.ReadLine();
        Console.Write(Player[0] + " currently has " + PlayerTotal[0]);
        Console.ReadLine();
        Console.Write(Player[1] + " currently has " + PlayerTotal[1]);
        Console.ReadLine();
