    public static IEnumerable<Tuple<T, T>> Combinate<T>(this IEnumerable<T> enumerable) {
        var outer = enumerable.GetEnumerator();
        var n = 1;
        while (outer.MoveNext()) {
            foreach (var item in enumerable.Skip(n))
                yield return Tuple.Create(outer.Current, item);
            n++;
        }
    }
