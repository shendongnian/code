    class Program
    {
        static void Main(string[] args)
        {
            int baseN = 4;
            int maxDigits = 10;
            var max = Math.Pow(baseN, maxDigits);
            for (int i = 0; i < max; i++)
            { // each iteration of this loop is another unique permutation
                var digits = new int[maxDigits];
                int value = i;
                int place = digits.Length - 1;
                while (value > 0)
                {
                    int thisdigit = value % baseN;
                    value /= baseN;
                    digits[place--] = thisdigit;
                }
                // now build up this permutation
                foreach (var digit in digits)
                {
                    Console.Write(digit);
                    switch (digit)
                    {
                        case 0: break; //choose Q
                        case 1: break; //choose R
                        case 2: break; //choose W
                        case 3: break; //choose T
                    }
                }
                Console.WriteLine();
                // add it to your list of all permutations here
            }
            Console.ReadLine();
        }
    }
