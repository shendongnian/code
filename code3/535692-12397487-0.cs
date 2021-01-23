    public interface IQuery<TResult> {}
    public interface IQueryProcessor
    {
        TResult Execute<TResult>(IQuery<TResult> query)
    }
    
