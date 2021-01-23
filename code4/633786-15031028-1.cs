    while ((enemyHealth > 0 || playerHealth > 0))
    { 
        Console.WriteLine("[System:] Here are the list of moves that you can do:\n1)Punch\n2)Kick\n3)Round House Kick");
        Console.WriteLine();
        decision = Console.ReadLine();
        Console.WriteLine();
        decisionNumber = int.Parse(decision);
        if (decisionNumber >= 1 && decisionNumber <= 3)
        {
            
            enemyHealth = enemyHealth - attackNumber;
            playerHealth = playerHealth - enemyAttackNumber;
            Console.WriteLine();
            Console.WriteLine("[System:] Enemy Health: " + enemyHealth + "\nYour Health: " + playerHealth);
        } 
        else
        {
            Console.WriteLine("Invalid Input : press enter to input again");
            Console.ReadKey();
        }
 
    }
