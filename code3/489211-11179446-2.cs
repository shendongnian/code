    public class StackOverflow_11179289
    {
        public static void Test()
        {
            int @base = 10;
            double exp = 12345.123;
            int intExp = (int)Math.Floor(exp);
            double fracExp = exp - intExp;
            BigInteger temp = BigInteger.Pow(@base, intExp);
            double temp2 = Math.Pow(@base, fracExp);
            int fractionBitsForDouble = 52;
            for (int i = 0; i < fractionBitsForDouble; i++)
            {
                temp = BigInteger.Divide(temp, 2);
                temp2 *= 2;
            }
            BigInteger result = BigInteger.Multiply(temp, (BigInteger)temp2);
            Console.WriteLine(result);
        }
    }
