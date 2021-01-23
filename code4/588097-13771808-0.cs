    public interface IDocument { ... }
    public interface IFilter<in TIn, out TOut> 
        where TIn: IDocument
        where TOut: IDocument
    {
        TOut Execute(TIn data);
    }
