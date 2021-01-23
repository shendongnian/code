    void TestPrimacyOfNUnsignedLongs(int n) {
      PrimeList List();  // Makes a list of all unsigned long primes
      for (int i = 0; i<n; i++) {
        unsinged long x = random_ul();
        if (List.IsAPrime(x)) DoThis();
      }
    }
