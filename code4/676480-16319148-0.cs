        public IQueryable<T> GetRecords()
        {
            var entities = Repository.Query<T>();
            if (typeof(IFilterable).IsAssignableFrom(typeof(T)))
            {
                //Filterme is a method that takes in IEnumerable<IFilterable>
                entities = FilterMe(entities).AsQueryable();
            }
            return entities;
        }
        public IEnumerable<T> FilterMe(IEnumerable<T> linked) 
        {
            var dict = GetDict();
            return linked.Where(r => dict.ContainsKey(r.Id));
        }
