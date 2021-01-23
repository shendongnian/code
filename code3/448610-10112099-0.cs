    public static int FirstCut(int[] g, int[] h)
    {
        Contract.Requires(h.Length == g.Length);
        Contract.Requires(Contract.Exists(0, g.Length, x => g[x] == h[x]));
        //Do whatever knowing that 2 values at index x in the arrays are the same
    }
