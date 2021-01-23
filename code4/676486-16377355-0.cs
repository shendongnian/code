        public class MyModel<T> : IModel<T> where T : MyObjectBase {
            public IQueryable<T> GetRecords()
        {
            var entities = Repository.Query<T>();
            if (typeof(IFilterable).IsAssignableFrom(typeof(T)))
            {
                //Filterme is a method that takes in IEnumerable<IFilterable>
                entities = FilterMe(entities.Cast<IFilterable>());
            }
            return entities;
        }
            public IEnumerable<T> FilterMe(IEnumerable<IFilterable> linked)  {
                var dict = GetDict();
                return linked
                        .Where(r => dict.ContainsKey(r.Id))
                        .Cast<T>();
            }
        }
