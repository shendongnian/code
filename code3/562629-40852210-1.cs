    class Program
    {
        static string backValue = "";
        static double value;
        static ConsoleKeyInfo inputKey;
        static void Main(string[] args)
        {
            Console.Title = "";
            Console.Write("Enter your value: ");
            do
            {
                inputKey = Console.ReadKey(true);
                if (char.IsDigit(inputKey.KeyChar))
                {
                    if (inputKey.KeyChar == '0')
                    {
                        if (!backValue.StartsWith("0") || backValue.Contains('.'))
                            Write();
                    }
                    else
                        Write();
                }
                if (inputKey.KeyChar == '-' && backValue.Length == 0 ||
                    inputKey.KeyChar == '.' && !backValue.Contains(inputKey.KeyChar) &&
                    backValue.Length > 0)
                    Write();
                if (inputKey.Key == ConsoleKey.Backspace && backValue.Length > 0)
                {
                    backValue = backValue.Substring(0, backValue.Length - 1);
                    Console.Write("\b \b");
                }
            } while (inputKey.Key != ConsoleKey.Enter); //Loop until Enter key not pressed
            if (double.TryParse(backValue, out value))
                Console.Write("\n{0}^2 = {1}", value, Math.Pow(value, 2));
            Console.ReadKey();
        }
        static void Write()
        {
            backValue += inputKey.KeyChar;
            Console.Write(inputKey.KeyChar);
        }
    }
