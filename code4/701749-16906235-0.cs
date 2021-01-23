You could do it in one pass by creating a List&lt;T&gt; and then returning it as an IEnumerable&lt;T&gt; type:
    public static IEnumerable<T> Exchange<T>(this IEnumerable<T> source, int index1, int index2)
    {
        // TODO: check index1 and index2 are in bounds of List/Enumerable
        var result = source.ToList(); // single enumeration
        // Swap vars
        var temp = result[index1];
        result[index1] = result[index2];
        result[index2] = temp;
        return result;
    }
