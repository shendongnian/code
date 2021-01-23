    private static int GetIntegerInput(string prompt)
    {
        int result;
        Console.WriteLine();
        while (true)
        {
            // THIS SHOULD OVERWRITE THE SAME PROMPT EVERY TIME
            Console.Write(prompt); 
            if (Int32.TryParse(Console.ReadLine(), out result))
            {
                break;
            }
        }
        return result;
    }
