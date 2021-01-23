    class DigitProducts
    {
        private static readonly int[] Prefilled = CreateFirst10000();
         
        private static int[] CreateFirst10000()
        {
            // Inefficient but simple, and only executed once.
            int[] values = new int[10000];
            for (int i = 0; i < 10000; i++)
            {
                int product = 1;
                foreach (var digit in i.ToString())
                {
                    product *= digit -'0';
                }
                values[i] = product;
            }
            return values;
        }
        
        public static IEnumerable<long> GetProducts(long startingPoint)
        {
            if (startingPoint >= 10000000000000000L || startingPoint < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            int a = (int) (startingPoint / 1000000000000L);
            int b = (int) ((startingPoint % 1000000000000L) / 100000000);
            int c = (int) ((startingPoint % 100000000) / 10000);
            int d = (int) (startingPoint % 10000);
            
            for (; a < 10000; a++)
            {
                long aMultiplier = a == 0 ? 1 : Prefilled[a];
                for (; b < 10000; b++)
                {
                    long bMultiplier = a == 0 && b == 0 ? 1
                                     : a != 0 && b < 1000 ? 0
                                     : Prefilled[b];
                    for (; c < 10000; c++)
                    {
                        long cMultiplier = a == 0 && b == 0 && c == 0 ? 1
                                         : (a != 0 || b != 0) && c < 1000 ? 0
                                         : Prefilled[c];
                        
                        long abcMultiplier = aMultiplier * bMultiplier * cMultiplier;
                        for (; d < 10000; d++)
                        {
                            long dMultiplier = 
                                (a != 0 || b != 0 || c != 0) && d < 1000 ? 0
                                : Prefilled[d];
                            yield return abcMultiplier * dMultiplier;
                        }
                        d = 0;
                    }
                    c = 0;
                }
                b = 0;
            }
        }
    }
