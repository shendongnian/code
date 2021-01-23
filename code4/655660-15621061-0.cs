    int numItems = 0;
    for(int i=0;i<MAX;i++)
    {
        Console.Write("Enter a name and a score for player #{0}: ", (i + 1));
        string input = Console.ReadLine();
        if (input == "")
        {
            break; // if nothing is entered, it will break the loop
        }
        numItems++;
        ...
    }
    static void CalculateScores(int[] score, int numItems)
    {
        // don't use Length at all, use numItems instead
    }
