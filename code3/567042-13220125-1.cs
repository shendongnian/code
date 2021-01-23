        while (iChoice < 1 || iChoice > 3)
        {
            Console.WriteLine("Menu choice not between 1-3: ");
            Console.Write("Please re-enter: ");
            iChoice = Convert.ToInt32(Console.ReadLine());
            Console.ReadKey();
        }
       
        Console.WriteLine("You have chosen option " + iChoice);
         
