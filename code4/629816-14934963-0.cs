    public static IEnumerable<MyObj> AsComponents<T>(this IEnumerable<T> serialized)
        where  T:class
    {
        using (var it = serialized.GetEnumerator())
        {
            Func<T> next = () => it.MoveNext() ? it.Current : null;
            var obj = new MyObj
                {
                    Name  = next(),
                    Id    = next(),
                    Other = next()
                };
            
            if (obj.Name == null)
                yield break;
            yield return obj;
        }
    }
