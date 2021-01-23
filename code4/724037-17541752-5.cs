    // Get prime divisors 
    private static IList<long> CoreGetPrimeDivisors(long value, IList<int> primes) {
      List<long> results = new List<long>();
    
      int v = 0;
      long threshould = (long) (Math.Sqrt(value) + 1);
    
      for (int i = 0; i < primes.Count; ++i) {
        v = primes[i];
    
        if (v > threshould)
          break;
    
        if ((value % v) != 0)
          continue;
    
        while ((value % v) == 0) {
          value = value / v;
    
          results.Add(v);
        }
    
        threshould = (long) (Math.Sqrt(value) + 1);
      }
    
      if (value > 1)
        results.Add(value);
    
      return results;
    }
    
    /// <summary>
    /// Get prime divisors 
    /// </summary>
    public static IList<long> GetPrimeDivisors(long value, IList<int> primes) {
      if (!Object.ReferenceEquals(null, primes))
        return CoreGetPrimeDivisors(value, primes);
    
      List<long> results = new List<long>();
    
      while ((value % 2) == 0) {
        results.Add(2);
    
        value = value / 2;
      }
    
      while ((value % 3) == 0) {
        results.Add(3);
    
        value = value / 3;
      }
    
      while ((value % 5) == 0) {
        results.Add(5);
    
        value = value / 5;
      }
    
      while ((value % 7) == 0) {
        results.Add(7);
    
        value = value / 7;
      }
    
      int v = 0;
      long n = (long) (Math.Sqrt(value) / 6.0 + 1);
      long threshould = (long) (Math.Sqrt(value) + 1);
    
      for (int i = 2; i <= n; ++i) {
        v = 6 * i - 1;
    
        if ((value % v) == 0) {
          while ((value % v) == 0) {
            results.Add(v);
    
            value = value / v;
          }
    
          threshould = (long) (Math.Sqrt(value) + 1);
        }
    
        v = 6 * i + 1;
    
        if ((value % v) == 0) {
          while ((value % v) == 0) {
            results.Add(v);
    
            value = value / v;
          }
    
          threshould = (long) (Math.Sqrt(value) + 1);
        }
    
        if (v > threshould)
          break;
      }
    
      if (value > 1) {
        if (results.Count <= 0)
          results.Add(value);
        else if (value != results[results.Count - 1])
          results.Add(value);
      }
    
      return results;
    }
    
    /// <summary>
    /// Get all divisors
    /// </summary>
    public static IList<long> GetDivisors(long value, IList<int> primes) {
      HashSet<long> hs = new HashSet<long>();
    
      IList<long> divisors = GetPrimeDivisors(value, primes);
    
      ulong n = (ulong) 1;
      n = n << divisors.Count;
    
      for (ulong i = 1; i < n; ++i) {
        ulong v = i;
        long p = 1;
    
        for (int j = 0; j < divisors.Count; ++j) {
          if ((v % 2) != 0)
            p *= divisors[j];
    
          v = v / 2;
        }
    
        hs.Add(p);
      }
    
      List<long> result = new List<long>();
    
      result.Add(1);
    
      var en = hs.GetEnumerator();
    
      while (en.MoveNext())
        result.Add(en.Current);
    
      result.Sort();
    
      return result;
    }
    
    /// <summary>
    /// Get all divisors
    /// </summary>
    public static IList<long> GetDivisors(long value) {
      return GetDivisors(value, null);
    }
