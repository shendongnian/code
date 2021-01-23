    public static long GetnCk(long n, long k)
    {
        long bufferNum = 1;
        long bufferDenom = 1;
        for(long i = n; i > Math.Abs(n-k); i--)
        {
            bufferNum *= i;
        }
        for(long i = k; i => 1; i--)
        {
            bufferDenom *= i;
        }
        return (long)(bufferNom/bufferDenom);
    }
