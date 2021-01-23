    public static void Permutations(int digits, int options)
    {
        double maxNumberDouble = Math.Ceiling(Math.Pow(options, digits));
        int maxNumber = (int)maxNumberDouble;
        for (int i = 0; i < maxNumber; i++)
        {
            Console.WriteLine(Convert.ToString(i, options).PadLeft(3, '0'));
        }
    }
