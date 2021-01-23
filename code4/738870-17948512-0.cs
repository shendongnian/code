    public sealed class UnitOfWork : IUnitOfWork 
    {
        private readonly MyContext _context;
        public UnitOfWork()
        {
            _context = new MyContext();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
