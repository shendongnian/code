    static void Main()
    {
        string input = //get your user input;
        short sNum = 0;
        while(!short.TryParse(input,out sNum))
        {
            Console.WriteLine("Input invalid, please try again");
            input = //get your user input;
        }
        Console.WriteLine("output is {0}",sNum);
        Console.ReadLine();
    }
