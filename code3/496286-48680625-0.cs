    public class SingletonContext<TContext>
        where TContext: DbContext,new()
    {
        private static TContext _context;
        private SingletonContext()
        {
        }
        public static TContext GetInstance()
        {
            if (_context == null)
            {
                _context = new TContext();
            }
            return _context;
        }
    }
