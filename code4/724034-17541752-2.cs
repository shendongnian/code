       public static long Solution(int factorsCount) {
          for (long i = 1; ; ++i) {
            long n = i * (i + 1) / 2;
    
            IList<long> factors = GetDivisors(n);
    
            // This tests if a triangle number has exactly factorsCount factors
            // if you want a triangle number which has at least factorsCount factors
            // change "==" comparison for ">=" one:
            // if (factors.Count >= factorsCount)  
            if (factors.Count == factorsCount) 
              return n;
          }
        }
    
      ...
      
      long solution = Solution(50);
