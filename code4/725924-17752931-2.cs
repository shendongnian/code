    static IEnumerable<int> GetProductDigitsFast()
    {
        // First generate the first 1000 values to cache them.
        int[] productPerThousand = new int[1000];
        
        // Up to 9
        for (int x = 0; x < 10; x++)
        {
            productPerThousand[x] = x;
            yield return x;
        }
        // Up to 99
        for (int y = 1; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                productPerThousand[y * 10 + x] = x * y;
                yield return x * y;
            }
        }
        // Up to 999
        for (int x = 1; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int z = 0; z < 10; z++)
                {
                    int result = x * y * z;
                    productPerThousand[x * 100 + y * 10 + z] = x * y * z;
                    yield return result;
                }
            }
        }
        
        // Now use the cached values for the rest
        for (int x = 0; x < 1000; x++)
        {
            int xMultiplier = x == 0 ? 1 : productPerThousand[x];
            for (int y = 0; y < 1000; y++)
            {
                // We've already yielded the first thousand
                if (x == 0 && y == 0)
                {
                    continue;
                }
                // If x is non-zero and y is less than 100, we've
                // definitely got a 0, so the result is 0. Otherwise,
                // we just use the productPerThousand.
                int yMultiplier = x == 0 || y >= 100 ? productPerThousand[y]
                                                     : 0;
                int xy = xMultiplier * yMultiplier;
                for (int z = 0; z < 1000; z++)
                {
                    if (z < 100)
                    {
                        yield return 0;
                    }
                    else
                    {
                        yield return xy * productPerThousand[z];
                    }
                }
            }
        }
    }
