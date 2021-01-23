    public class OrderClause<T>
    {
        private Func<IQueryable<T>, IOrderedQueryable<T>> m_orderingFunction;
        public void AddOrderBy<TProperty>(Expression<Func<T, TProperty>> orderBySelector)
        {
            if (m_orderingFunction == null)
            {
                m_orderingFunction = q => q.OrderBy(orderBySelector);
            }
            else
            {
                // required so that m_orderingFunction doesn't reference itself
                var orderingFunction = m_orderingFunction;
                m_orderingFunction = q => orderingFunction(q).ThenBy(orderBySelector);
            }
        }
        public IQueryable<T> Order(IQueryable<T> source)
        {
            if (m_orderingFunction == null)
                return source;
            return m_orderingFunction(source);
        }
    }
