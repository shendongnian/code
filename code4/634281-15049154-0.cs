    public class MyContext : DbContext
    {
        public IDbSet<Thing> Things { get; set; }
        public IQueryable<Thing> EnabledThings
        {
            get
            {
                return Things.Where(t => t.Enabled);
            }
        }
    }
