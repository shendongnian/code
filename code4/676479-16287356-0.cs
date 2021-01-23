    public class MyModel<T> : IModel<T> where T : MyObjectBase
    {
        public IQueryable<T> GetRecords()
        {
            var entities = Repository.Query<T>();
            if (typeof(IFilterable).IsAssignableFrom(typeof(T)))
            {
                //Filterme is a method that takes in IEnumerable<IFilterable>
                entities = FilterMe(entities));
            }
            return entities;
        }
         public IEnumerable<TResult> FilterMe<TResult>(IEnumerable<TResult> linked) where TResult :  IFilterable
        {
            var dict = GetDict();
            return linked.OfType<TResult>().Where(r => dict.ContainsKey(r.Id));
        }
    }
