    int paragraphsEntered = 0;
    string line = Console.ReadLine();
    while(!string.IsNullOrEmpty(line))
    {
        paragraphsEntered++
        line = Console.ReadLine();
    }
    Console.WriteLine("You entered {0} paragraph(s).", paragraphsEntered);
