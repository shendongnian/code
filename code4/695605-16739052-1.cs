    BigInteger bigInt = 10000000000000000000;  // myBigInt is a huge BigInt i want to find the Log of.
    double log;
    log = BigInteger.Log(bigInt, 1000); //Find the Log
    System.Diagnostics.Debug.WriteLine(log.ToString());
    System.Diagnostics.Debug.WriteLine(((Int32)log).ToString());
    BigInteger bigIntRecreate;
    // unless log is an integer value it will round down and will not recreate to proper value
    bigIntRecreate = BigInteger.Pow(1000, (Int32)log);
    System.Diagnostics.Debug.WriteLine(bigInt.ToString("N0"));
    System.Diagnostics.Debug.WriteLine(bigIntRecreate.ToString("N0"));
    System.Diagnostics.Debug.WriteLine((bigInt - bigIntRecreate).ToString("N0"));
