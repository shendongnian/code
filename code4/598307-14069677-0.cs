    Random random = new Random();
    Console.WriteLine("Please enter the name of the numbers file");
    string fileLotto = Console.ReadLine();
    StringBuilder text = new StringBuilder();
    for(int i = 0; i < 6; i++)
    {
        for(int j = 0; j < 7; j++)
        {
            text.Append(random.Next(1, 49) + " " );
        }
        Console.WriteLine();
    }
    File.WriteAllText(string.Format("../../{0}.txt", fileLotto), text.ToString());
