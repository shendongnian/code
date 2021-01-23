    public static void Main (string[] args)
    {
        int[] userInput = new int[100];
        int xuserInput = int.Parse (userInput);
        for (int i = 0; i<userInput.Length; i++)
        {
            int temp = int.Parse(Console.ReadLine());
            userInput[i] = temp;
            if (userInput == "")
                break;
        }
        Console.WriteLine (userInput);
    }
