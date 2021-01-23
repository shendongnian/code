    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
      // Preconditions:
      // * items is a sequence of non-negative monotone increasing integers
      // * n is the number of items to be in the subsequence
      // * sum is the desired sum of that subsequence.
      // Result:
      // A sequence of subsequences of the original sequence where each 
      // subsequence has n items and the given sum.
      static IEnumerable<IEnumerable<int>> M(IEnumerable<int> items, int sum, int n)
      {
        // Let's start by taking some easy outs. If the sum is negative
        // then there is no solution. If the number of items in the
        // subsequence is negative then there is no solution.
    
        if (sum < 0 || n < 0)
          yield break;
    
        // If the number of items in the subsequence is zero then
        // the only possible solution is if the sum is zero.
        
        if (n == 0)
        {
          if (sum == 0)
            yield return Enumerable.Empty<int>();
          yield break;
        }
    
        // If the number of items is less than the required number of 
        // items, there is no solution.
    
        if (items.Count() < n)
          yield break;
    
        // We have at least n items in the sequence, and
        // and n is greater than zero, so First() is valid:
        int first = items.First();
    
        // We need n items from a monotone increasing subsequence
        // that have a particular sum. We might already be too 
        // large to meet that requirement:
     
        if (n * first > sum)
          yield break;
    
        // There might be some solutions that involve the first element.
        // Find them all.
    
        foreach(var subsequence in M(items.Skip(1), sum - first, n - 1))
          yield return new[]{first}.Concat(subsequence);      
    
        // And there might be some solutions that do not involve the first element.
        // Find them all.
        foreach(var subsequence in M(items.Skip(1), sum, n))
          yield return subsequence;
      }
      static void Main()
      {
        int[] x = {0, 1, 2, 3, 4, 5};
        for (int i = 0; i <= 15; ++i)
          foreach(var seq in M(x, i, 4))
            Console.WriteLine("({0}) SUM {1}", string.Join(",", seq), i);
      }
    }       
