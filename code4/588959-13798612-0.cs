      Console.Write("Enter the name of Player 1: ");
      Player[0] = Console.ReadLine();
      Console.Write("Enter the name of Player 2: ");
      Player[1] = Console.ReadLine();
      Random DiceRandom = new Random();
        
      do
        {
            int i = 0;
            while (i <= 1)
            {
                DiceThrow[0 + i] = DiceRandom.Next(1, 7);
                Console.ReadLine();
                Console.Write(Player[0 + i] + " rolled a " + DiceThrow[0 + i]);
                if (DiceThrow[0 + i] != 6) i++;
            }
            Console.ReadLine();
            PlayerTotal[0] += DiceThrow[0];
            PlayerTotal[1] += DiceThrow[1];
            Console.ReadLine();
            Console.Write(Player[0] + " currently has " + PlayerTotal[0]);
            Console.ReadLine();
            Console.Write(Player[1] + " currently has " + PlayerTotal[1]);
            Console.ReadLine();
        }
        while (PlayerTotal[0] < 20 && PlayerTotal[1] < 20);
