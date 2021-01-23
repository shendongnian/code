    bool IsPrime(int test) {
      for (int i = 3; i * i <= test; i = 2 + i)
        if (test % i == 0)
          return false;
      return true;
    }
    
    void PrintPrimes(int numberRequired) {
      if (numberRequired < 1)
        return;
      int primeTest = 3;
      /****** UPDATE NEXT TWO LINES TO TEST FOR != *****/
      int numPrimes = 2;  // set numPrimes = 1 for !=
      while (numPrimes != numberRequired) {  // switch <= to !=
        if (IsPrime(primeTest)) {
          ++numPrimes;
        }
        primeTest += 2;
      }
    }
    
    int  main() 
    {
      long totalTicks = 0;
      for (int i = 0; i < 100; ++i) {
        PrintPrimes(15000);
      }
    }
