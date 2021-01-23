      class Program
        {
            static int Main()
            {
                Numbers nbs = new Numbers();
                const int Total = 10;
                ArrayList lstNumbers = nbs.RandomNumbers(Total);
    
                for (int i = 0; i < lstNumbers.Count; i++)
                    Console.WriteLine("{0}", lstNumbers[i].ToString());
     
                return 0;
            }
        }
    }
