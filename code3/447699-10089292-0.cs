    int[] frostDays = new int[100];
    
    for (int i = 0; i < 100; i++)
    {    
    	System.Random RandNum = new System.Random();
    	int nyrHiti = RandNum.Next(-10, 50);
    	Console.WriteLine(nyrHiti);
    }
    Console.ReadLine();
    
    Console.WriteLine(frostDays[0]);
    Console.ReadLine();
