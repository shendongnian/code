    static void Main()
    {
        String input = //get your user input;
        short sNum = 0;
        while(!Int16.TryParse(input,out sNum))
        {
            Console.WriteLine("Input invalid, please try again");
            String input = //get your user input;
        }
        Console.WriteLine("output is {0}",sNum);
        Console.ReadLine();
    }
