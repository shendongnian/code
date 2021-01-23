    public static IEnumerable<int> LeafPositions(byte octet)
    {
    	var i = 1;
        for (; octet > 0; octet >>= 1)
        {
            if ((octet & 1) == 1)
            {
            	yield return i;
            }
            
            i++;
        }
    }
