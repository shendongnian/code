    public static TOutput Decode<TInput, TOutput>(TInput expression, params Tuple<TInput, TOutput>[] searchResultPairs)
        => DecodeWithDefault(expression, default(TOutput), searchResultPairs);
    public static TOutput DecodeWithDefault<TInput, TOutput>(TInput expression, TOutput defaultValue, params Tuple<TInput, TOutput>[] searchResultPairs)
    {
        foreach(var searchResultPair in searchResultPairs)
        {
            if ((expression == null && searchResultPair.Item1 == null)
                || (expression != null && expression.Equals(searchResultPair.Item1)))
            {
                return searchResultPair.Item2;
            }
        }
        return defaultValue;
    }
