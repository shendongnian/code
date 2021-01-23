    static void Main(string[] args)
    {
        const int QUIT = -1;
        string inputStr;
        int i1 = 0;
        int i2 = 0;
        int i3 = 0;
        int inputInt = 0;
        do
        {
            Console.Write("Type a number (type -1 to quit): ");
            inputStr = Console.ReadLine();
            bool inputBool = int.TryParse(inputStr, out inputInt);
            if (inputBool == true)
            {
                i3 = i2;
                i2 = i1;
                i1 = inputInt;
            }
            Console.WriteLine("Sum of the past three numbers is: {0}", i1+i2+i3);
        } while (inputInt != QUIT);
    }
