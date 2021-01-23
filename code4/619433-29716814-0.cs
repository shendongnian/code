    static class EnumerableExtensions {
    
      public static IEnumerable Zip<TSource, TResult>(
        this IEnumerable<IEnumerable<TSource>> source,
        Func<IEnumerable<TSource>, TResult> resultSelector
      ) {
        if (source == null)
          throw new ArgumentNullException("source");
        if (resultSelector == null)
          throw new ArgumentNullException("resultSelector");
    
        var enumerators = new List<IEnumerator<TSource>>();
        try {
          foreach (var enumerable in source) {
            if (enumerable == null)
              throw new ArgumentNullException();
            enumerators.Add(enumerable.GetEnumerator());
          }
    
          while (enumerators.Aggregate(true, (moveNext, enumerator) => moveNext && enumerator.MoveNext()))
            yield return resultSelector(enumerators.Select(enumerator => enumerator.Current));
        }
        finally {
          foreach (var enumerator in enumerators)
            enumerator.Dispose();
        }
      }
    
    }
