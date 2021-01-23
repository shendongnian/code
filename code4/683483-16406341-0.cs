    static void Main(string[] args)
    {
        const int QUIT = -1;
        string inputStr;
        int inputInt = 0,tempint=0;
        do
        {
            Console.Write("Type a number (type -1 to quit): ");
            inputStr = Console.ReadLine();
            bool inputBool = int.TryParse(inputStr, out tempint);
            if (inputBool == true)
            {
                inputInt += tempint;
            }
            Console.WriteLine("Sum of the past three numbers is: {0}", inputInt);
        } while (tempint!= QUIT);
    }
