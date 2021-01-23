    public static IEnumerable<T> AsIEnumerable<T>(this T obj)
    {
        yield return obj;
    }  
    var appended = source.Concat(element.AsEnumerable())
