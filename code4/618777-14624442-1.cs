    static Random Rangen = new Random();
    static void PlaatsSnoep(int aantal)
    {
        int[,] PlaatssnoepArray = new int[aantal,2];
        for (int i = 0; i < aantal; i++)
        {
            int SnoepX = Rangen.Next(25, 94);
            int SnoepY = Rangen.Next(3, 23);
            Console.SetCursorPosition(SnoepX, SnoepY);
            Console.WriteLine("0");
            PlaatssnoepArray[i, 0] = SnoepX;
            PlaatssnoepArray[i, 1] = SnoepY;
        }
    }
