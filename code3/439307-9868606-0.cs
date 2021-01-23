        public class MyDbContextProxy : IDbContext {
            DbContext _context = null;
            public MyDbContextProxy(DbContext interceptedContext) {
                _context = interceptedContext;
            }
            // decorated method
            public int SaveChanges() {
                _context.SaveChanges();
            }
        }
