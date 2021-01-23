    private static string randomBit()
    {
        int bitSize = 0, input = 0;
        Console.Write("Input Bit Size (Maximum is 16 Bit): ");
        input = Convert.ToInt32(Console.ReadLine());
        Random choice = new Random();
        if (input == 0 || input > 16)
        {
            bitSize = 0;
        }
        else if(input == 1)
        {
            bitSize = 1;
        }
        else
        {                        
            int randomChoice = choice.Next(1 << (input-1), (1 << input)-1);
            bitSize = randomChoice;
        }
        string binary = Convert.ToString(bitSize, 2);
        return binary;
    }
