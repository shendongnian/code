    switch (key)
        {
            case 'e':
                wantsContinue = false;
                break;
            case 'r':
                Console.WriteLine("\nYippeeee! I get to run again");
                Console.WriteLine("Please enter your commands");                        
                string input = Console.ReadLine();
                Method1(parameters);
                break;
            case 'h':
                Console.WriteLine(helpMsg);
                break;
            default:
                Console.WriteLine("\nInvalid argument. Enter again");
                break;
        }
