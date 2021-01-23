    public interface IInvoker<in TParameter, out TResult> : IProcessable
    {
        TResult Invoke(TParameter parameter);
    }
    public abstract class Processable { }
    public class InvokerOne : Processable, IInvoker<Parameter1, Result1> { /* ... */ }
    public class InvokerTwo : Processable, IInvoker<Parameter2, Result2> { /* ... */ }
    Processable[] invokers = { new InvokerOne(), new InvokerTwo() };
