    static void Main(string[] args)
            {
                System.Random generator = new Random(DateTime.Now.Millisecond); int[] lotteryNumber = new int[7];
    
                Console.WriteLine("Your lottery numbers: ");
                for (int i = 0; i < 7; i++)
                {
                    int lNumber = 0;
                    do
                    {
                        lNumber = generator.Next(1, 37);
                    }
                    while (lotteryNumber.Contains(lNumber));
                    lotteryNumber[i] = lNumber;
    
                    Console.Write("{0} ", lotteryNumber[i]);
                }
                Console.ReadLine();
            }
