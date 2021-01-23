    public delegate void ActionWithOut<T>(out T result);
    public static void ConvertOut<TBase, TDerived>(
        ActionWithOut<TDerived> method, out TBase result)
        where TDerived : TBase
    {
        TDerived derived;
        method(out derived);
        result = derived;
    }
