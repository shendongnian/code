    [ThreadStatic]
    private static Dictionary<int,double[]> _scratchArrays;
    private static Dictionary<int,double[]> scratchArrays
    {
        get
        {
            if (_scratchArrays == null)
            {
                _scratchArrays = new Dictionary<int,double[]>();
            }
            return _scratchArrays;
        }
    }
    /// Round up to next higher power of 2 (return x if it's already a power of 2).
    public static int Pow2RoundUp (int x)
    {
        if (x < 0)
            return 0;
        --x;
        x |= x >> 1;
        x |= x >> 2;
        x |= x >> 4;
        x |= x >> 8;
        x |= x >> 16;
        return x+1;
    }
    private static double[] GetScratchArray(int size)
    {
        int pow2 = Pow2RoundUp(size);
        if (!scratchArrays.ContainsKey(pow2))
        {
            scratchArrays.Add(pow2, new double[pow2]);
        }
        return scratchArrays[pow2];
    }
