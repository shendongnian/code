    public class ValidationQueryHandlerDecorator<TQuery, TResult>
        : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IServiceProvider provider;
        private readonly IQueryHandler<TQuery, TResult> decorated;
     
        public ValidationQueryHandlerDecorator(
            Container container,
            IQueryHandler<TQuery, TResult> decorated)
        {
            this.provider = container;
            this.decorated = decorated;
        }
     
        public TResult Handle(TQuery query)
        {
            var validationContext =
                new ValidationContext(query, this.provider, null);
     
            Validator.ValidateObject(query, validationContext);
            return this.decorated.Handle(query);
        }
    }
