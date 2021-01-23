    class Program
    {
        static void Main(string[] args)
        {
            int[] userInput = new int[10];
            for(int count = 0; count <= 9; count++)
            {
                int number;
                string input = Console.ReadLine();
                bool result = Int32.TryParse(input, out number);
                if (result)
                {
                    userInput[count] = number;
                }
                else if (!result)
                {
                    if (input != string.Empty)
                        Console.WriteLine("Not a valid number.");
                    else if (input.Equals(string.Empty))
                    {
                        foreach (var item in userInput)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        return;
                    }
                }
            }
        }
    }
