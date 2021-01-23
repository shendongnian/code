        public class Query
        {
        private QueryName _name;
        private IList<Query> _subQueries = new List<Query>();
        private IList<Criterion> _criteria = new List<Criterion>();
        public Query()
            : this(QueryName.Dynamic, new List<Criterion>())
        { }
        public Query(QueryName name, IList<Criterion> criteria)
        { 
            _name = name;
            _criteria = criteria;
        }
        public QueryName Name
        {
            get { return _name; }
        }
        public bool IsNamedQuery()
        {
            return Name != QueryName.Dynamic;
        }
        public IEnumerable<Criterion> Criteria
        {
            get {return _criteria ;}
        }          
        public void Add(Criterion criterion)
        {
            if (!IsNamedQuery())
                _criteria.Add(criterion);
            else
                throw new ApplicationException("You cannot add additional criteria to named queries");
        }
        public IEnumerable<Query> SubQueries
        {
            get { return _subQueries; }
        }
        public void AddSubQuery(Query subQuery)
        {
            _subQueries.Add(subQuery);
        }
        public QueryOperator QueryOperator { get; set; }
        public OrderByClause OrderByProperty { get; set; }
        }
