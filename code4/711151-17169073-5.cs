    public class Repository<T> where T : class
    {
        private readonly Context context;
        public Repository(Context context)
        {
            this.context = context;
        }
        protected virtual T InsertOrUpdate(T e, int id)
        {
            T instance = context.Set<T>().Create();
            if (e.GetType().Equals(instance.GetType()))
            {
                instance = e;
            }
            else
            {
                DbEntityEntry<T> entry = context.Entry(instance);
                entry.CurrentValues.SetValues(e);
            }
            context.Entry<T>(instance).State =
                id == default(int)
                    ? EntityState.Added
                    : EntityState.Modified;
            return instance;
        }
    }
