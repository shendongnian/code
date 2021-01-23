    // Defines a query
    public interface IQuery<TResult>
    {
    }
    // Defines the handler that will execute queries
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
