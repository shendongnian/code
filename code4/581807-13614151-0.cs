    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<MyDbContext>(null);
            var context = new MyDbContext(@"Data Source=.;Initial Catalog=Play;Integrated Security=True;");
            PageService service = new PageService(context);
            while (true)
            {
                Console.WriteLine("Please enter a page id: ");
                var pageId = Console.ReadLine();
                var detail = service.GetNavigationFor(Int32.Parse(pageId));
                if (detail.HasPreviousPage())
                {
                    Console.WriteLine(@"Previous page ({0}) {1} {2}", detail.PreviousPage.Id, detail.PreviousPage.Name, detail.PreviousPage.Created);
                }
                else
                {
                    Console.WriteLine(@"No previous page");
                }
                Console.WriteLine(@"Current page ({0}) {1} {2}", detail.CurrentPage.Id, detail.CurrentPage.Name, detail.CurrentPage.Created);
                if (detail.HasNextPage())
                {
                    Console.WriteLine(@"Next page ({0}) {1} {2}", detail.NextPage.Id, detail.NextPage.Name, detail.NextPage.Created);
                }
                else
                {
                    Console.WriteLine(@"No next page");
                }
                Console.WriteLine("");
            }
        }
    }
    public class PageService
    {
        public MyDbContext _context;
        public PageService(MyDbContext context)
        {
            _context = context;
        }
        public NavigationDetails GetNavigationFor(int pageId)
        {
            var previousPage = _context.Pages.OrderByDescending(p => p.Created).Where(p => p.Id < pageId).FirstOrDefault();
            var nextPage = _context.Pages.OrderBy(p => p.Created).Where(p => p.Id > pageId).FirstOrDefault();
            var currentPage = _context.Pages.FirstOrDefault(p => p.Id == pageId);
            return new NavigationDetails()
            {
                PreviousPage = previousPage,
                NextPage = nextPage,
                CurrentPage = currentPage
            };
        }
    }
    public class NavigationDetails
    {
        public Page PreviousPage { get; set; }
        public Page CurrentPage { get; set; }
        public Page NextPage { get; set; }
        public bool HasPreviousPage()
        {
            return (PreviousPage != null);
        }
        public bool HasNextPage()
        {
            return (NextPage != null);
        }
    }
    public class MyDbContext : DbContext
    {
        public MyDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        public DbSet<Page> Pages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PageMap());
        }
    }
    public class PageMap : EntityTypeConfiguration<Page>
    {
        public PageMap()
        {
            ToTable("t_Pages");
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Name);
            Property(m => m.Created);
        }
    }
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
    }
