    System.Random RandNum = new System.Random();
    int[] frostDays = new int[100];
    for (int i = 0; i < 100; i++) {
        int nyrHiti = RandNum.Next(-10, 50);
        Console.WriteLine(nyrHiti);
        frostDays[i] = nyrHiti;
    }
    Console.ReadLine();
    Console.WriteLine(frostDays[0]);
    Console.ReadLine();
