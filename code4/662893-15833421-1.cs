    private static void InputItems(int itemsbought)
    {
        Console.WriteLine("Enter the amount of items you bought");
        if (!int.TryParse(Console.ReadLine(), out itemsbought) || itemsbought < 0)
        {
            Console.WriteLine("Error, whole numbers over 0 only");
        }
    }
