        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }
        
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
