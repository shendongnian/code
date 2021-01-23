    bool stillRunning = true;
    
    while (stillRunning)
    {
        Console.WriteLine("Enter a number.");
        string input = Console.ReadLine();
        int key = Convert.ToInt32(input);
        switch (key)
        {
            case 1:
                // Do something.
                stillRunning = false;
                break;
            case 2:
                // Do something.
                stillRunning = false;
                break;
            default:
                Console.WriteLine("No key selected.");
                break;
        }
    } 
