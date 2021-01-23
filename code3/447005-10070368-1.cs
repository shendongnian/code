    public class Repository
    {
        private readonly IObjectContext _context;
        public void Repository(IObjectContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetList<T>() where T : class
        {
            return _context.CreateObjectSet<T>().ToList();
        }        
    }
