    public interface IUnitOfWork : IDisposable
    {
        // ...
    }
    public class ConcreteUnitOfWork : IUnitOfWork, IDisposable
    {
        private MyDbContext _context;
        // I assume that you have a member for the DbContext in this class
        // ...
        // implementation of IDisposable
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
