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
                int choice = 0;
                foreach (var digit in digits)
                {
                    choice ++;
                    //Console.Write(digit);
                    switch (digit)
                    {
                        case 0: break; //choose Q from choice
                        case 1: break; //choose R from choice
                        case 2: break; //choose W from choice
                        case 3: break; //choose T from choice
                    }
                }
                //Console.WriteLine();
                // add it to your list of all permutations here
            }
            Console.WriteLine("Done")
            Console.ReadLine();
        }
    }
