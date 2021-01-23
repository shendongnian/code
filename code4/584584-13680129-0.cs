    static TResult call<TResult>(Func<TResult> f)
    {
        return f();
    }
    static TResult call<T1, TResult>(Func<T1,TResult> f, T1 arg1)
    {
        return f(arg1);
    }
    static TResult call<T1, T2, TResult>(Func<T1, T2, TResult> f, T1 arg1, T2 arg2)
    {
        return f(arg1, arg2);
    }
    // and so on...
    static void Main(string[] args)
    {
        Console.WriteLine(call(() => "test"));
    }
