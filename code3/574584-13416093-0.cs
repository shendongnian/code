    static class ThreeWayZip
    {
      public static IEnumerable<TResult> Zip3<TFirst, TSecond, TThird, TResult>(
    	  this IEnumerable<TFirst> first,
    	  IEnumerable<TSecond> second,
          IEnumerable<TThird> third,
          Func<TFirst, TSecond, TThird, TResult> resultSelector)
      {
        if(first == null || second == null || third == null) 
        { throw new ArgumentNullException(); }
    
        using (var iterator1 = first.GetEnumerator())
        using (var iterator2 = second.GetEnumerator())
        using (var iterator3 = third.GetEnumerator())
        {
          while(iterator1.MoveNext() 
            && iterator2.MoveNext()
            && iterator3.MoveNext())
          {
            yield return resultSelector(
              iterator1.Current, iterator2.Current, iterator3.Current);
          }
          
        }
      }
    }
