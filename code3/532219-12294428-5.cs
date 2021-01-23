    int check = 0;
    
    int[] lotto = new int[6];
    
    Random rand = new Random();
                
    int i = 0;
    
    while (i < lotto.Length)
    {
        check = rand.Next(1, 41);
        Console.WriteLine("Random number to be checked is -> " + check);
    
        if (!lotto.Contains(check))
        {
            lotto[i] = check;
            i++;
        }
    
        Console.WriteLine("slot " + i + " contains " + check);
    }
    
    Console.ReadKey();
