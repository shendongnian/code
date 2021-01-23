    public class Query
    {
        public IEnumerable<T> GetData<T, U, TKey>(Expression<Func<T, TKey>> tKey, Expression<Func<U, TKey>> uKey)
        {
            Context context = new Context();
            // using the extension method as the query expression had trouble figuring out the types
            var data = context.GetTable<T>().Join(context.GetTable<U>(), tKey, uKey, (tblT, tblU) => tblT);            
            
            return data;
        }
    }
