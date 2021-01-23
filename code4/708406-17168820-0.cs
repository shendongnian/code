    public class DepthRecursionGuard : ISpecimenBuilderNode
    {
        private readonly ISpecimenBuilder builder;
        private readonly Stack<object> monitoredRequests;
        public DepthRecursionGuard(ISpecimenBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            this.monitoredRequests = new Stack<object>();
            this.builder = builder;
        }
        public object Create(object request, ISpecimenContext context)
        {
            if (this.monitoredRequests.Count(request.Equals) > 1)
                return this.HandleRecursiveRequest(request);
            this.monitoredRequests.Push(request);
            var specimen = this.builder.Create(request, context);
            this.monitoredRequests.Pop();
            return specimen;
        }
        private object HandleRecursiveRequest(object request)
        {
            if (typeof(IEnumerable<B>).Equals(request))
                return Enumerable.Empty<B>();
            throw new InvalidOperationException("boo hiss!");
        }
        public ISpecimenBuilderNode Compose(IEnumerable<ISpecimenBuilder> builders)
        {
            var builder = ComposeIfMultiple(builders);
            return new DepthRecursionGuard(builder);
        }
        public virtual IEnumerator<ISpecimenBuilder> GetEnumerator()
        {
            yield return this.builder;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private static ISpecimenBuilder ComposeIfMultiple(
            IEnumerable<ISpecimenBuilder> builders)
        {
            var isSingle = builders.Take(2).Count() == 1;
            if (isSingle)
                return builders.Single();
            return new CompositeSpecimenBuilder(builders);
        }
    }
