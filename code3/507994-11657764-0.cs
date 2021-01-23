    using System.Numerics;
    
    public static BigInteger Calc(int number)
    {
        BigInteger rValue = 1;
        for (int i = 0; i < number; i++)
        {
            rValue = rValue * (ulong)(number - i);
        }
        return rValue;
    }
