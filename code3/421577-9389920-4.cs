        for (int n = -10; n < 10; n++)
        {
            if (Class1.IsPrimeCorrect(n) != Class1.IsPrimeIncorrect(n))
            {
                Console.WriteLine(n);
            }
        }
