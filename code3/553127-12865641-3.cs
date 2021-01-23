    public static IEnumerable<T> AsEnumerable<T>(this ArraySegment<T> segment)
    {
        for (int i = 0; i < segment.Count; i++)
        {
            yield return segment.Array[segment.Offset + i];
        }
    }
    ...
    ArraySegment<double> segment = ...
    foreach (double d in segment.AsEnumerable())
    {
        ...
    }
