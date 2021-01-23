    public static IEnumerable<T> MoveSelectedLeft<T>(
        this IEnumerable<T> source,
        IEnumerable<int> indicesToMove /* must be in order! */)
    {
        Queue<int> toMove = new Queue<int>(indicesToMove);
        bool canMoveYet = false;
        T held = default(T);
        int currentIndex = 0;
        foreach(T t in source)
        {
            if (toMove.Count > 0 && toMove.Peek() == currentIndex)
            {
                toMove.Dequeue();
                yield return t;
            }
            else
            {
                if (!canMoveYet)
                    canMoveYet = true;
                else
                    yield return held;
                held = t;
            }
            currentIndex++;
        }
        if (canMoveYet)
            yield return held;
    }
