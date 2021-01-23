    public static UInt64 GetNthFibonacciNumber(uint n)
        {
    
        // Return the nth fibonacci number based on n.
    if (n == 1 || n == 2)
        {
            return 1;
        }
        uint a = 1;
        uint b = 1;
        uint c;
        for (uint i = 3; i <= n; i++)
        {
            c = b + a;
            a = b;
            b = c;
        }
        return c;
}
