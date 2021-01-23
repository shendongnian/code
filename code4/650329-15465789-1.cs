    bool valid = false;
    while (!valid)
    {
        Console.WriteLine("\nEntrez le type d'employé (c ou g) : ");
        var key = Console.ReadKey();
        switch (char.ToLower(key.KeyChar))
        {
            case 'c':
                // your processing
                valid = true;
                break;
            case 'g':
                // your processing
                valid = true;
                break;
            default:
                Console.WriteLine("Invalid. Please try again.");
                break;
        }
    }
