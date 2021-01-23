    public delegate TResult OutFunc<TIn, TOut, TResult>(TIn input, out TOut output);
    public static Func<TIn, Tuple<TResult, TOut>> OutToTuple<TIn, TOut, TResult>(
        OutFunc<TIn, TOut, TResult> outFunc)
    {
        return input =>
        {
            TOut output;
            TResult result = outFunc(input, out output);
            return Tuple.Create(result, output);
        };
    }
