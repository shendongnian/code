    public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source) { 
        IEnumerable<TResult> typedSource = source as IEnumerable<TResult>;
        if (typedSource != null) return typedSource; 
        if (source == null) throw Error.ArgumentNull("source");
        return CastIterator<TResult>(source);
    }
 
    static IEnumerable<TResult> CastIterator<TResult>(IEnumerable source) {
        foreach (object obj in source) yield return (TResult)obj; 
    } 
