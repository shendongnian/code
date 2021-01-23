            ConsoleKey choice;
            do
            {
               choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    // 1 ! key
                    case ConsoleKey.D1:
                        Console.WriteLine("1. Choice");
                        break;
                    //2 @ key
                    case ConsoleKey.D2:
                        Console.WriteLine("2. Choice");
                        break;
                }
            } while (choice != ConsoleKey.D1 && choice != ConsoleKey.D2);
