    public static long GetnCk(long n, long k)
    {
        long buffern = 1;
        long bufferk = 1;
        long bufferkn = 1;
        for(long i = n; i => 1; i--)
        {
            buffern *= i;
        }
        for(long i = k; i => 1; i--)
        {
            bufferk *= i;
        }
        for(long i = (Math.Abs(n-k)); i => 1; i--)
        {
            bufferkn *= i;
        }
        return (long)(buffern/(bufferk*bufferkn));
    }
