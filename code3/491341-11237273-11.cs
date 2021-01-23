    public abstract class Repository<T>  where T : IDomainModelEntity
    {
        protected readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public abstract IQueryable<T> GetAll();
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }
    }
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context)
            : base(context)
        {
        }
        public override IQueryable<User> GetAll()
        {
            return _context.Set<DBUser>()
                .Select(u => new User
                    {
                        Id = u.USER_ID,
                        Name = u.USER_NAME,
                        Email = u.USER_MAIL
                    });
        }
    }
