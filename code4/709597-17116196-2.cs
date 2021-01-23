    void Foo(int userNumber)
    {
        int userNumber = 500;
        for (int i = 0; i < 10; i++ )
        {
            int firstNumber = Next(0, userNumber - 1);
            int secondNumber = userNumber - firstNumber;
            Console.WriteLine(firstNumber + "+" + secondNumber);
        }
    }
    internal static int RandomExt(int min, int max)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buffer = new byte[4];
        rng.GetBytes(buffer);
        int result = BitConverter.ToInt32(buffer, 0);
        return new Random(result).Next(min, max);
    }
