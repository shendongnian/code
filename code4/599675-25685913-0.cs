        private static void checkpirme(int x)
        {
            for (int i = 1; i <= x; i++)
            {
                if (i == 1 || x == i)
                {
                    continue;
                }
                else
                {
                    if (x % i == 0)
                    {
                        Console.WriteLine(x + " is not prime number");
                        return;
                    }
                }
            }
            Console.WriteLine(x + " is  prime number");
        }
