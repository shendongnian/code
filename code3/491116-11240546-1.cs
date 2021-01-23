     //Base Class 
    class ReportBase<T> where T: class
    {
        private DbContext _context;
        public ReportBase(DbContext context)
        {
            _context = context;
        }
        
        //I think GetAll is a more suitable name for your method than load :D
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
        
        public IQueryable<T> Filter(Func<T,bool> filterFunction)
        {   
             var result = from p in GetAll()
                          where filterFunction(p)
                          select p;
             return result;
        }
    }
