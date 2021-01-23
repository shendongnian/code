    void prime_num(long num)
        {
            bool isPrime = true;
            for (int i = 0; i <= num; i++)
            {
                for (int j = 2; j <= num; j++)
                {
                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.WriteLine ( "Prime:" + i );
                }
                isPrime = true;
            }
        }
