    BigInteger bi = 2;
    for ( int i = 0; i < 1234; i++ )
        {
           bi *= 2;
        }
    string myBigIntegerNumber = bi.ToString();
    Console.WriteLine(BigInteger.Parse(myBigIntegerNumber));
