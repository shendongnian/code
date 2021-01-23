    static void Main()
    {
        WriteNumbers(3);
    }
    static void WriteNumbers(int digits, int number = 0)
    {
        int i = (number % 10) + 1;
        number *= 10;
        for (; i <= 9; i++)
        {
            if (digits == 1)
                Console.WriteLine(number + i);
            else
                WriteNumbers(digits - 1, number + i);
        }
    }
