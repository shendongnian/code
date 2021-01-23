    static void Main()
    {
        string[] words = { "casino", "other word" };
    
        if (words.Contains("casino"))
        {
            Console.WriteLine("The word is found");
        }
        else
        {
            Console.WriteLine("The word is not found");
        }
       
        Console.Read();
    }
