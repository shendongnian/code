    // Helper method to count set bits in an integer
    public static int CountBits(int n)
    {
    	int count = 0;
    	while (n != 0)
    	{
    	    count++;
    	    n &= (n - 1);
    	}
    	return count;
    }
    public static IEnumerable<IEnumerable<T>> PowerSet<T>(
        IEnumerable<T> src, 
        int minSetSize = 0, 
        int maxSetSize = int.MaxValue)
    {
        // we want fast random access to the source, so we'll
        // need to ToArray() it
        var cached = src.ToArray();
        var setSize = Math.Pow(2, cached.Length);
        for(int i=0; i < setSize; i++)
        {
            var subSetSize = CountBits(i);
            if(subSetSize < minSetSize || 
               subSetSize > maxSetSize)
            {
                continue;
            }
            T[] set = new T[subSetSize];
    
            var temp = i;
            var srcIdx = 0;
            var dstIdx = 0;
            while(temp > 0)
            {
                if((temp & 0x01) == 1)
                {
                    set[dstIdx++] = cached[srcIdx];
                }
                temp >>= 1;
                srcIdx++;            
            }
            yield return set;
        }
        yield break;
    }
