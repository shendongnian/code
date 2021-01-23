    public sealed class UnitOfWork : IUnitOfWork 
    {
        private readonly MyContext _context;
        public UnitOfWork(MyContext context)
        {
            _context = context;
        }
    }
