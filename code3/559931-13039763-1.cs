    bool loop = true;
    
    while (loop)
    {
        loop = false;
        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("you chose 1");
                break;
            case "2":
                Console.WriteLine("you chose 2");
                break;
            case "3":
                Console.WriteLine("you chose 3");
                break;
            case "4":
                Console.WriteLine("you chose 4");
                break;
            case "5":
                Console.WriteLine("you chose 5");
                break;
            default:
                loop = true;
                break;
        }
    }
