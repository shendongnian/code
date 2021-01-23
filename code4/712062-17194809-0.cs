    public partial class Repository<T> : IRepository<T> where T : BaseEntity
        {
            private readonly DatabaseContext _context;
            private IDbSet<T> _entities;
    
            public Repository(DatabaseContext context)
            {
                this._context = context;
            }
    		public virtual IQueryable<T> GetCollection()
            {
                get
                {
                    return this.Entities;
                }
            }
       }
