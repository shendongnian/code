    static IEnumerable<T> ScrambleStart(this IEnumerable<T> source,
            int numberToScramble)
    {
      using(var iter = source.GetEnumerator()) {
        List<T> list = new List<T>();
        while(iter.MoveNext()) {
            list.Add(iter.Current);
            if(list.Count == numberToScramble) break;
        }
        ScrambleList(list); // your existing code
        foreach(var item in list) yield return item;
        while(iter.MoveNext()) {
            yield return iter.Current;
        }
      }
    }
