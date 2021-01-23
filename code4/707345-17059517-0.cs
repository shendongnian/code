    public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> superset, int pageSize)
    {
      if (superset.Count() < pageSize)
        yield return superset;
      else
      {
        var numberOfPages = Math.Ceiling(superset.Count() / (double)pageSize);
        for (var i = 0; i < numberOfPages; i++)
          yield return superset.Skip(pageSize * i).Take(pageSize);	
      }
    }
