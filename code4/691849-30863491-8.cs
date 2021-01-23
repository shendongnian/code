    public static IEnumerable<int> LeafPositions(byte octet)
    {
        for (var i = 1; octet > 0; octet >>= 1, i++)
        {
            if ((octet & 1) == 1)
            {
            	yield return i;
            }
        }
    }
