    static IEnumerable<int> GetProductDigitsSlow()
    {
        for (int i = 0; i < 1000000000; i++)
        {
            int product = 1;
            foreach (var digit in i.ToString())
            {
                product *= digit -'0';
            }
            yield return product;
        }
    }
