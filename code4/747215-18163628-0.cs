    public interface ISortable<T>
    {
        Pageable<T> ResetOrder();
        Pageable<T> AddOrder(Expression<Func<T, object>> orderBy);
        Pageable<T> AddOrderDescending(Expression<Func<T, object>> orderBy);
    }
    
    public class Pageable<T> : ISortable<T>, IEnumerable<T> {
        class SortKey {
            public Expression<Func<T, object>> Expression { get; set; }
            public bool Descending { get; set; }
        }
    
        List<SortKey> _sortKeys = new List<SortKey>();
    
        System.Linq.IQueryable<T> _sourceQuery;
    
        int _pageNumber;
        int _pageSize;
    
        public Pageable<T> SetPage(int pageNumber, int pageSize) {
            _pageNumber = pageNumber;
            _pageSize = pageSize;
            return this;
        }
    
        public Pageable<T> ResetOrder()
        {
            _sortKeys.Clear();
            return this;
        }
    
        public Pageable<T> AddOrder(Expression<Func<T, object>> orderBy)
        {
            _sortKeys.Add(new SortKey {
                Expression = orderBy, 
                Descending = false
            });
            return this;
        }
    
        public Pageable<T> AddOrderDescending(Expression<Func<T, object>> orderBy)
        {
            _sortKeys.Add(new SortKey {
                Expression = orderBy, 
                Descending = true
            });
            return this;
        }
    
        IEnumerable<T> SortAndPage()
        {
            if (_sortKeys.Count == 0) 
            {
                return Page(_sourceQuery);
            }
    
            var firstKey = _sortKeys[0];
            var orderedQuery = firstKey.Descending 
                ? _sourceQuery.OrderByDescending(firstKey.Expression) 
                : _sourceQuery.OrderBy(firstKey.Expression);
    
            foreach (var key in _sortKeys.Skip(1)) 
            {
                orderedQuery = key.Descending ? orderedQuery.ThenByDescending(key.Expression) : orderedQuery.ThenBy(key.Expression);
            }
            return Page(orderedQuery);
        }
    
        IEnumerable<T> Page(IQueryable<T> query) 
        {
            return query.Skip((_pageNumber - 1) * _pageSize)
                        .Take (_pageSize);
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return SortAndPage().GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
