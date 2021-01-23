        private const decimal Epislon = 0.001m;
        private const decimal Upper = 1 + Epislon;
        private const decimal Lower = 1 - Epislon;
        private static bool NewTest(decimal[] list)
        {
            var listLength = list.Length;
            var variations = (int)(Math.Pow(2, listLength) - 1);
            for (var variation = variations; variation > 0; variation--)
            {
                decimal sum = 0;
                int mask = 1;
                for (var bit = listLength; bit > 0; bit--)
                {
                    if ((variation & mask) == mask)
                    {
                        sum += list[bit - 1];
                    }
                    mask <<= 1;
                }
                if (sum > Lower && sum < Upper)
                {
                    return true;
                }
            }
            return false;
        }
