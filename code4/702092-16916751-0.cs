    public class GenericRepository<T>
    {
        protected IDbSet<T> Query<T>()
        {
            return myContext.GetDbSet<T>();
        }
        public IEnumerable<T> Where<T>(Expression<Func<T, bool>> predicate)
        {
            return Query<T>().Where(predicate).ToList();
        }
   
       ...
    }
