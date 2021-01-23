    public class UnitOfWork<TContext> : IDisposable
        where TContext: DbContext, new()
    {
        public TContext Context { get; private set; }
    
        public UnitOfWork(TContext context)
        {
            Context = context;
        }
    
        public UnitOfWork() : this(new TContext())
        {
        }
    
        public void Commit()
        {
            Context.SaveChanges();
        }
    
        public void Dispose()
        {
        }
    }
