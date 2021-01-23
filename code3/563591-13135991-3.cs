    public class TlsCachingQueryHandlerDecorator<TQuery, TResult>
        : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : class
    {
        [ThreadStatic]
        private static TResult cache;
    
        public ValidationQueryHandlerDecorator(
            IQueryHandler<TQuery, TResult> decorated)
        {
            this.decorated = decorated;
        }
     
        public TResult Handle(TQuery query)
        {
            return cache ?? (cache = this.decorated.Handle(query));
        }
    }
