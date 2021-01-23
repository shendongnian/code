    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class
    {
        public abstract IQueryable<T> Select();
        public abstract void Save(T item);
        public abstract void Delete(T item);
        public abstract void Delete(IEnumerable<T> items);
        public virtual Expression<Func<T, T, bool>> KeyCompare { get; private set; }
        public virtual int Count { get { return Select().Count(); } }
        protected RepositoryBase(Expression<Func<T, T, bool>> keyCompare)
        {
            KeyCompare = keyCompare;
        }
        public virtual T Item(T item)
        {
            var applied = PartialApplier.PartialApply(KeyCompare, item);
            var result = (Select().SingleOrDefault(applied));
            return result;
        }
        /// <summary>
        /// A method that updates the non-key fields of an existing entity with those of specified <see cref="item"/>.
        /// Called by the <see cref="Save"/> method.
        /// </summary>
        /// <param name="existing">The existing record to update.</param>
        /// <param name="item">A <see cref="T"/> object containing the values to update <see cref="existing"/> object with.</param>
        /// <returns></returns>
        protected abstract void UpdateExisting(T existing, T item);
        /// <summary>
        /// A method that saves all specified items.
        /// </summary>
        /// <param name="items">The entities to be saved.</param>
        public virtual void Save(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Save(item);
            }
        }
    }
