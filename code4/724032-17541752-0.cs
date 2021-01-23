       public static long Solution(int factorsCount) {
          for (long i = 1; ; ++i) {
            long n = i * (i + 1) / 2;
    
            IList<long> factors = GetDivisors(n);
    
            if (factors.Count == factorsCount) 
              return n;
          }
        }
    
      ...
      
      long solution = Solution(50);
