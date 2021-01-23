    public static IEnumerable<T> MoveSelectedLeft<T>(
        this IEnumerable<T> source,
        IEnumerable<int> indicesToMove /* must be in order! */)
    {
        using (var itm = indicesToMove.GetEnumerator())
        {
            bool hasNextToMove = itm.MoveNext();
            int nextToMove = hasNextToMove ? itm.Current : -1;
            bool canMoveYet = false;
            T held = default(T);
            int currentIndex = 0;
            foreach (T t in source)
            {
                if (hasNextToMove && nextToMove == currentIndex)
                {
                    hasNextToMove = itm.MoveNext();
                    nextToMove = hasNextToMove ? itm.Current : -1;
                    yield return t;
                }
                else
                {
                    if (!canMoveYet)
                    {
                        canMoveYet = true;
                    }
                    else
                    {
                        yield return held;
                    }
                    held = t;
                }
                currentIndex++;
            }
            if (canMoveYet)
                yield return held;
        }
    }
