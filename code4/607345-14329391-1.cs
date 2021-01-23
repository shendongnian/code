    public interface IInvoker<in TParameter, out TResult>
    //                        ^^             ^^^
    //                        Look!          Here too!
    {
        TResult Invoke(TParameter parameter);
    }
