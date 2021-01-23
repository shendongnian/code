    public class Machine
    {
        public int MachineId { get; set; }
        public int InstalledOSId { get; set; }
        public InstalledOS InstalledOS { get; set; }
        public int LicenceTypeId { get; set; }
        public LicenceType LicenceType { get; set; }
    }
    public class InstalledOS
    {
        public int InstalledOSId { get; set; }
    }
    public class LicenceType
    {
        public int LicenceTypeId { get; set; }
    }
    public class Context : DbContext
    {
        public DbSet<Machine> Machines { get; set; }
        public DbSet<LicenceType> LicenceTypes { get; set; }
        public DbSet<InstalledOS> InstalledOSs { get; set; }
    }
    public class Repository<T> where T : class
    {
        private DbSet<T> _dbSet;
        public Repository(DbSet<T> dbset)
        {
            _dbSet = dbset;
        }
        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
            Context context = new Context();
            InstalledOS os1 = new InstalledOS();
            context.InstalledOSs.Add(os1);
            LicenceType l1 = new LicenceType();
            context.LicenceTypes.Add(l1);
            Machine m1 = new Machine
            {
                InstalledOS = os1, 
                LicenceType = l1
            };
            context.Machines.Add(m1);
            context.SaveChanges();
            Repository<Machine> repo = new Repository<Machine>(context.Machines);
            var query = repo.AllIncluding(m => m.InstalledOS, m => m.LicenceType);
            Machine m2 = query.First();
            Console.WriteLine(m2.InstalledOS.InstalledOSId);
            Console.ReadLine();
        }
    }
