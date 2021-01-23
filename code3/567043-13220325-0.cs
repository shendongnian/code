        Console.WriteLine("1: Add two numbers");
        Console.WriteLine("2: Multiply two numbers");
        Console.WriteLine("3: Exit the program");
        Console.WriteLine("Enter your choice:");
        int iChoice;
        while (true)
        {
          iChoice = Convert.ToInt32(Console.ReadLine());
          if (iChoice >= 1 && iChoice <=3)
            break; // choice is OK
          Console.WriteLine("Menu choice not between 1-3.");
          Console.Write("Please re-enter:");
        }
        Console.WriteLine("You have chosen option " + iChoice);
        // ...
