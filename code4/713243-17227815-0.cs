    public IEnumerable<Tuple<T, T, T>> WithNextAndPrevious<T>
        (this IEnumerable<T> source)
    {
        // Actually yield "the previous two" as well as the current one - this
        // is easier to implement than "previous and next" but they're equivalent
        using (IEnumerator<T> iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                yield break;
            }
            T lastButOne = iterator.Current;
            if (!iterator.MoveNext())
            {
                yield break;
            }
            T previous = iterator.Current;
            while (iterator.MoveNext())
            {
                T current = iterator.Current;
                yield return Tuple.Create(lastButOne, previous, current);
                lastButOne = previous;
                previous = current;
            }
        }        
    }
