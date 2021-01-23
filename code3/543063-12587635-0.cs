    public sealed class OrderQueryResults : IOrderQueryResults
    {
        private const string DisplayName = "OrderName";
        
        private const string ValueName = "OrderNum";
        
        private readonly IEnumerable<IOrderQueryResult> results;
        private readonly object extra;
        private OrderQueryResults(IEnumerable<IOrderQueryResult> results, object extra)
        {
            this.results = results;
            this.extra = extra;
        }
        public string DisplayMember
        {
            get
            {
                return DisplayName;
            }
        }
        public string ValueMember
        {
            get
            {
                return ValueName;
            }
        }
        public IEnumerable<IOrderQueryResult> Results
        {
            get
            {
                return this.results;
            }
        }
        public object Extra
        {
            get
            {
                return this.extra;
            }
        }
        public static IOrderQueryResults Create(IEnumerable<IOrderQueryResult> results, object extra)
        {
            if (results == null)
            {
                throw new ArgumentNullException("results");
            }
            return new OrderQueryResults(results.ToList(), extra);
        }
    }
