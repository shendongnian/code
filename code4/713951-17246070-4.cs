    public class NoDatabaseInitializer<T> : IDatabaseInitializer<T> where T: DbContext
    {
        public void InitializeDatabase(T context)
        {
            // Do nothing, thats the sense of it!
        }
    }
