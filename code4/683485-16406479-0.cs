    static void Main(string[] args)
    {
        const int QUIT = -1;
        string inputStr;
        List<int> allNumbers = new List<int>();
        do
        {
            Console.Write("Type a number (type -1 to quit): ");
            inputStr = Console.ReadLine();
            bool inputBool = int.TryParse(inputStr, out inputInt);
            if (inputBool == true)
                allNumbers.Add(inputInt); // Add a new element to the list
            Console.WriteLine("Sum of the past " + allNumbers.Count + " numbers is: {0}", allNumbers.Sum());
        } while (inputInt != QUIT);
    }
