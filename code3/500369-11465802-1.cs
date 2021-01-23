        public IQueryable<TEntity1> Populate<TEntity>(Func<TEntity, TEntity1> predicate)
        {
            return (IQueryable<TEntity1>)_objectSet.Select(predicate);
        }
        public IDictionary<int, string> Populatelist()
        {
            var dic = _repository.Populate<DTO.Category>(category => new DTO.Category() { category.CategoryID, category.CategoryName }).ToList();
            return dic.ToDictionary(c => c.CategoryID, c => c.CategoryName);
        }
