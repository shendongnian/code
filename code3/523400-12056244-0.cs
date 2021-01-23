    public class Context : IDisposable
    {
        [ThreadStatic]
        private static Context context;
    
        private Context(Guid id)
        {
            this.Id = id;
        }
    
        public Guid Id
        {
            get;
            private set;
        }
    
        public static Context Instance()
        {
            if (context == null)
            {
                context = new Context(Guid.NewGuid());
            }
    
            return context;
        }
    
        public void Dispose()
        {
            context = null;
        }
    }
