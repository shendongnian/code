    class Program
    {
        bool CheckIsPrimeNumber(int primeNum)
        {
            bool isPrime = false;
            for (int i = 2; i <= primeNum / 2; i++)
            {
                if (primeNum % i == 0)
                {
                    return isPrime;
                }
            }
            return !isPrime;
        }
        public static void Main(string[] args)
        {
            Program obj = new Program();
            Console.Write("Enter the number to check prime  :  ");
            int mPrimeNum = int.Parse(Console.ReadLine());
            if (obj.CheckIsPrimeNumber(mPrimeNum) == true)
            {
                Console.WriteLine("\nThe " + mPrimeNum + " is a Prime Number");
            }
            else
            {
                Console.WriteLine("\nThe " + mPrimeNum + " is Not a Prime Number");
            }
            Console.ReadKey();
        }
    }
