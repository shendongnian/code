    public static void Main (string[] args)
    {
        int[] userInput = new int[100];
        for (int i = 0; i<userInput.Length; i++)
        {
            string input = Console.ReadLine ();
            if (input == "")
                break;
            else
                int.TryParse(input, out userInput[i]);
        }
        Console.WriteLine (userInput);
    }
