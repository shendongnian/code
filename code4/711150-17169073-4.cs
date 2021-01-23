    public class Repository<T> where T : class
    {
        private readonly Context context;
        private bool mapCreated = false;
        public Repository(Context context)
        {
            this.context = context;
        }
        protected virtual T InsertOrUpdate(T e, int id)
        {
            T instance = context.Set<T>().Create();
            if (e.GetType().Equals(instance.GetType()))
                instance = e;
            else
            {
                if (!mapCreated)
                {
                    Mapper.CreateMap(e.GetType(), instance.GetType());
                    mapCreated = true;
                }
                instance = Mapper.Map(e, instance);
            }
            if (id == default(int))
                context.Set<T>().Add(instance);
            else
                context.Entry<T>(instance).State = EntityState.Modified;
            return instance;
        }
    }
