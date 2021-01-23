    public interface IProcessable { }
    public interface IInvoker<in TParameter, out TResult> : IProcessable
    {
        TResult Invoke(TParameter parameter);
    }
    public class InvokerOne : IInvoker<Parameter1, Result1> { /* ... */ }
    public class InvokerTwo : IInvoker<Parameter2, Result2> { /* ... */ }
    IProcessable[] invokers = { new InvokerOne(), new InvokerTwo() };
