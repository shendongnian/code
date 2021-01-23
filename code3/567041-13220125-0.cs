        while (iChoice < 1 || iChoice > 3)
        {
            Console.WriteLine("Menu choice not between 1-3: ");
            Console.Write("Please re-enter: ");
            iChoice = Convert.ToInt32(Console.ReadLine());
            Console.ReadKey();
        }
         if  (iChoice >= 1 && iChoice <= 3)
         {
            Console.WriteLine("You have chosen option " + iChoice);
            iChoice = Convert.ToInt32(Console.ReadLine());
            Console.ReadKey();
         }
