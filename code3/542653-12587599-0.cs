    public static IEnumerable<T> Shift<T>(this IEnumerable<T> subject, T shouldBeFirst)
    {
        return subject.Shift(shouldBeFirst, EqualityComparer<T>.Default);
    }
    public static IEnumerable<T> Shift<T>(this IEnumerable<T> subject, T shouldBeFirst, IEqualityComparer<T> comparer)
    {
        var found = false;
        var queue = new Queue<T>();
        foreach (var item in subject)
        {
            if(!found)
                found = comparer.Equals(item, shouldBeFirst);
            if(found)
                yield return item;
            else
                queue.Enqueue(item);
        }
        while(queue.Count > 0)
            yield return queue.Dequeue();
    }
