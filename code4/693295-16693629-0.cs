    public class OrderClauseList<T>
    {
        privat readonly List<LambdaExpression> _list = new List<LambdaExpression>();
        public void AddOrderBy<TProperty>(Expression<Func<T, TProperty>> orderBySelector)
        {
            _list.Add(orderBySelector);
        }
    
        public IEnumerable<LambdaExpression> OrderByClauses
        {
            get { return _list; }
        }
    }
    public class Repository<T>
    {
        private IQueryable<T> _source = ... // Don't know how this works
        public IEnumerable<T> Query(OrderClause<T> clauseList)
        {
            // Needs validation, e.g. null-reference or empty clause-list. 
            var clauses = clauseList.OrderByClauses;
    
            IOrderedQueryable<T> result = Queryable.OrderBy(_source, 
                                                            (dynamic)clauses.First());
    
            foreach (var clause in clauses.Skip(1))
            {
                result = Queryable.ThenBy(result, (dynamic)clause);
            }
    
            return result.ToList();
        }
    }
