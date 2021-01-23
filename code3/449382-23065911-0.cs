    public class FakeRavenQueryable<T> : IRavenQueryable<T> {
        private readonly IQueryable<T> source;
        public FakeRavenQueryable(IQueryable<T> source, RavenQueryStatistics stats = null) {
            this.source = source;
            this.QueryStatistics = stats;
        }
        public RavenQueryStatistics QueryStatistics { get; set; }
        public Type ElementType {
            get { return typeof(T); }
        }
        public Expression Expression {
            get { return this.source.Expression; }
        }
        public IQueryProvider Provider {
            get { return new FakeRavenQueryProvider(this.source, this.QueryStatistics); }
        }
        public IRavenQueryable<T> Customize(Action<IDocumentQueryCustomization> action) {
            return this;
        }
        public IRavenQueryable<TResult> TransformWith<TTransformer, TResult>() where TTransformer : AbstractTransformerCreationTask, new() {
            throw new NotImplementedException();
        }
        public IRavenQueryable<T> AddQueryInput(string name, RavenJToken value) {
            throw new NotImplementedException();
        }
        public IRavenQueryable<T> Spatial(Expression<Func<T, object>> path, Func<SpatialCriteriaFactory, SpatialCriteria> clause) {
            throw new NotImplementedException();
        }
        public IRavenQueryable<T> Statistics(out RavenQueryStatistics stats) {
            stats = this.QueryStatistics;
            return this;
        }
        public IEnumerator<T> GetEnumerator() {
            return this.source.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return this.source.GetEnumerator();
        }
    }
    public class FakeRavenQueryProvider : IQueryProvider {
        private readonly IQueryable source;
        private readonly RavenQueryStatistics stats;
        public FakeRavenQueryProvider(IQueryable source, RavenQueryStatistics stats = null) {
            this.source = source;
            this.stats = stats;
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) {
            return new FakeRavenQueryable<TElement>(this.source.Provider.CreateQuery<TElement>(expression), this.stats);
        }
        public IQueryable CreateQuery(Expression expression) {
            var type = typeof(FakeRavenQueryable<>).MakeGenericType(expression.Type);
            return (IQueryable)Activator.CreateInstance(type, this.source.Provider.CreateQuery(expression), this.stats);
        }
        public TResult Execute<TResult>(Expression expression) {
            return this.source.Provider.Execute<TResult>(expression);
        }
        public object Execute(Expression expression) {
            return this.source.Provider.Execute(expression);
        }
    }
