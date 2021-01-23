    var result = list.ToKeyValuePairs(x => x.A)
                     .Select(x => new { A = x.Key, Bs = x.Value.Select(y => y.B) }); 
    foreach (var item in result)
    {
        Console.WriteLine("A = {0} Bs=[{1}]",item.A, String.Join(",",item.Bs));
    }
-
    public static class MyExtensions
    {
        public static IEnumerable<KeyValuePair<S,IEnumerable<T>>> ToKeyValuePairs<T,S>(
                this IEnumerable<T> list, 
                Func<T,S> keySelector)
        {
            List<T> retList = new List<T>();
            S prev = keySelector(list.FirstOrDefault());
            foreach (T item in list)
            {
                if (keySelector(item).Equals(prev))
                    retList.Add(item);
                else
                {
                    yield return new KeyValuePair<S, IEnumerable<T>>(prev, retList);
                    prev = keySelector(item);
                    retList = new List<T>();
                    retList.Add(item);
                }
            }
            if(retList.Count>0)
                yield return new KeyValuePair<S, IEnumerable<T>>(prev, retList);
        }
    }
